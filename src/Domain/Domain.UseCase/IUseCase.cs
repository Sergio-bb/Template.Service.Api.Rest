namespace Template.Service.Api.Rest.Domain.UseCase;

public interface IUseCase<T, TP>
{
    T Execute(TP type);
}