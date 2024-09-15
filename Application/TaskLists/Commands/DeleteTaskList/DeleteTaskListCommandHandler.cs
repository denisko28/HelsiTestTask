using Application.Interfaces.Repositories;
using Application.Utils;

namespace Application.TaskLists.Commands.DeleteTaskList;

public class DeleteTaskListCommandHandler(ITaskListsRepository repository) : IDeleteTaskListCommandHandler
{
    public async Task<Result<bool>> HandleAsync(DeleteTaskListCommand command)
    {
        var taskListId = command.Id;
        var taskList = await repository.GetByIdAsync(taskListId);
        
        if (taskList == null)
            return Result<bool>.Fail($"The tasks list with id: '{taskListId}' was not found.");
        if (!taskList.IsOwnedBy(command.CurrentUserId))
            return Result<bool>.Fail("Can not delete. You are not the owner of the task list.");

        await repository.DeleteAsync(taskListId);
        return Result<bool>.Success(true);
    }
}