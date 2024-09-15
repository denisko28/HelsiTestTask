using Application.Utils;
using Domain.Entities;
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.CreateTaskList;

public interface ICreateTaskListCommandHandler : ICommandHandler<CreateTaskListCommand, Result<TaskList>>
{
    
}