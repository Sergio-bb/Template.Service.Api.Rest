using Template.Service.Api.Rest.Domain.Model;
using Template.Service.Api.Rest.Domain.UseCase.Ports;

namespace Template.Service.Api.Rest.Domain.UseCase;

public class CreateUserUseCase : IUseCase<Task<User>, User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(User user)
    {
        return await _userRepository.AddAsync(user);
    }
}