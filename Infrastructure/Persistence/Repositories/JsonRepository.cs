using Application.Contracts.Persistence;
using Domain.Entities;
using System.Text.Json;

namespace Infrastructure.Persistence.Repositories;

// Make methods synchronized to prevent concurrency issues
public class JsonRepository<T> : IRepository<T> where T : class, IEntity
{
    // NOTE : Repository assumes that the entity has the same name as the JSON file
    private static readonly string? _rootDirectory = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
    private readonly string _filePath = Path.GetFullPath(Path.Combine(_rootDirectory ?? "app", $"../Infrastructure/DataStore/{typeof(T).Name.ToLower()}.json"));

    private readonly SemaphoreSlim _semaphore = new(1, 1); // SemaphoreSlim for async locking


    public async Task<T> AddAsync(T entity)
    {
        List<T> entities = await ReadFromFileAsync();

        // Auto increments the ID
        long maxId = entities.Count != 0 ? entities.Max(x => x.Id) : 0;
        entity.Id = maxId + 1;

        entities.Add(entity);
        await WriteToFileAsync(entities);
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        List<T> entities = await ReadFromFileAsync();
        List<T> updatedList = entities.Where(x => x.Id != entity.Id).ToList();
        await WriteToFileAsync(updatedList);
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        List<T> entities = await ReadFromFileAsync();
        return entities.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await ReadFromFileAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        List<T> entities = await ReadFromFileAsync();
        T? existingEntity = entities.FirstOrDefault(x => x.Id == entity.Id);
        if (existingEntity != null)
        {
            List<T> updatedList = entities.Where(x => x.Id != entity.Id).ToList();
            entities.Add(entity);
            await WriteToFileAsync(updatedList);
        }
    }

    private async Task<List<T>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return [];

        await _semaphore.WaitAsync();
        try
        {
            string json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? [];
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task WriteToFileAsync(List<T> entities)
    {
        string json = JsonSerializer.Serialize(entities);

        await _semaphore.WaitAsync();
        try
        {
            await File.WriteAllTextAsync(_filePath, json);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}