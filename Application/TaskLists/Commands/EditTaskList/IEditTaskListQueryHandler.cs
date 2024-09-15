using Application.Utils;
using Domain.Entities;
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.EditTaskList;

public interface IEditTaskListCommandHandler : ICommandHandler<EditTaskListCommand, Result<TaskList?>>
{
    
}