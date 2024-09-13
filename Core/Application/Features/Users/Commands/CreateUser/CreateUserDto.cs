namespace Application.Features.Users.Commands.CreateUser;
public class CreateUserDto
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public AddressDto Address { get; set; } = new();
    public string Phone { get; set; } = "";
    public string Website { get; set; } = "";
    public CompanyDto Company { get; set; } = new();
}