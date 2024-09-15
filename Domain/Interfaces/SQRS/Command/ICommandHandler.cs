namespace Domain.Interfaces.SQRS.Command;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand
{
    Task<TResponse> HandleAsync(TCommand command);
}