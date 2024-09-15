using Application.Utils;
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.DeleteTaskList;

public interface IDeleteTaskListCommandHandler : ICommandHandler<DeleteTaskListCommand, Result<bool>>
{
    
}