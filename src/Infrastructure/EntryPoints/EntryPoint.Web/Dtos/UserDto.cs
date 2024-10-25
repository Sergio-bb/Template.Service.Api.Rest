using Template.Service.Api.Rest.Domain.Model;

namespace Template.Service.Api.Rest.EntryPoint.Web.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public User ToDomain()
    {
        return new User { Id = Id, Name = Name, LastName = LastName };
    }
}