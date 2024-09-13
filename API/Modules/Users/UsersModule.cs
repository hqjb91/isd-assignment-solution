using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.RemoveUserById;
using Application.Features.Users.Queries.GetAllUsers;
using Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Users;

public class UserModule : IModule
{
    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        // services.AddScoped<IExampleService, ExampleService>();
        return services;
    }

    public RouteGroupBuilder MapEndpoints(RouteGroupBuilder group)
    {
        /// <summary>
        /// GET: /user
        /// Retrieves a list of all users.
        /// </summary>
        /// <param name="mediatR">The IMediator service used to send the GetAllUsersQuery.</param>
        /// <returns>A list of all users.</returns>
        group.MapGet("user",
          (
            [FromServices] IMediator mediatR
          ) =>
          {
              return mediatR.Send(new GetAllUsersQuery());
          })
          .WithName("GetUsers")
          .WithOpenApi(operation => new(operation)
          {
              Summary = "Get list of all Users"
          })
          ;

        /// <summary>
        /// GET: /user/{userId}
        /// Retrieves details of a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <param name="mediatR">The IMediator service used to send the GetUserByIdQuery.</param>
        /// <returns>The details of the user with the specified ID.</returns>
        group.MapGet("user/{userId}",
          (
            [FromRoute] long userId,
            [FromServices] IMediator mediatR
          ) =>
          {
              return mediatR.Send(new GetUserByIdQuery() { Id = userId });
          })
          .WithName("GetUserById")
          .WithOpenApi(operation => new(operation)
          {
              Summary = "Get User By Id"
          })
          ;

        /// <summary>
        /// DELETE: /user/{userId}
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <param name="mediatR">The IMediator service used to send the RemoveUserByIdCommand.</param>
        /// <returns>A result indicating the success or failure of the deletion.</returns>
        group.MapDelete("user/{userId}",
          (
            [FromRoute] long userId,
            [FromServices] IMediator mediatR
          ) =>
          {
              return mediatR.Send(new RemoveUserByIdCommand() { Id = userId });
          })
          .WithName("RemoveUserById")
          .WithOpenApi(operation => new(operation)
          {
              Summary = "Deletes a User by Id"
          })
          ;

        /// <summary>
        /// POST: /user
        /// Creates a new user.
        /// </summary>
        /// <param name="createUserCommand">The CreateUserCommand object containing the new user's details.</param>
        /// <param name="mediatR">The IMediator service used to send the CreateUserCommand.</param>
        /// <returns>The result of the user creation process.</returns>
        group.MapPost("user",
          (
            [FromBody] CreateUserCommand createUserCommand,
            [FromServices] IMediator mediatR
          ) =>
          {
              return mediatR.Send(createUserCommand);
          })
          .WithName("CreateUser")
          .WithOpenApi(operation => new(operation)
          {
              Summary = "Create a new User"
          })
          ;

        return group;
    }
}