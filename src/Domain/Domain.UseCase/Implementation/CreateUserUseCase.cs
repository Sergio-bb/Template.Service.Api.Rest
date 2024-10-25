using Template.Service.Api.Rest.Domain.Model;
using Template.Service.Api.Rest.Domain.UseCase;
using Template.Service.Api.Rest.Domain.UseCase.Ports;

namespace None.Template.Service.Api.Rest.Domain.UseCase.Implementation;

public class CreateUserUseCase(IUserRepository userRepository) : IUseCase<Task<User>, User>
{
    public async Task<User> Execute(User user)
    {
        return await userRepository.AddAsync(user);
    }
}