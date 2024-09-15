using Application.Utils;
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.UnshareTaskListCommand;

public interface IUnshareTaskListCommandHandler : ICommandHandler<UnshareTaskListCommand, Result<bool>>
{
    
}