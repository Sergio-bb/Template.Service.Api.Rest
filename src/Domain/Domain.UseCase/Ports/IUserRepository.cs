using Template.Service.Api.Rest.Domain.Model;

namespace Template.Service.Api.Rest.Domain.UseCase.Ports;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
}