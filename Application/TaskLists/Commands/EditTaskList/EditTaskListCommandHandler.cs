using Application.Interfaces.Repositories;
using Application.Utils;
using AutoMapper;
using Domain.Entities;

namespace Application.TaskLists.Commands.EditTaskList;

public class EditTaskListCommandHandler(ITaskListsRepository repository, IMapper mapper) : IEditTaskListCommandHandler
{
    public async Task<Result<TaskList?>> HandleAsync(EditTaskListCommand command)
    {
        var taskList = await repository.GetByIdAsync(command.Id);
        
        if (taskList == null)
            return Result<TaskList>.Fail($"The tasks list with id: '{command.Id}' was not found.");
        if(!taskList.IsOwnedBy(command.CurrentUserId))
            return Result<TaskList>.Fail("Can not edit. You are not the owner of the task list.");
        
        mapper.Map(command, taskList);
        await repository.UpdateAsync(taskList);
        return Result<TaskList?>.Success(taskList);
    }
}