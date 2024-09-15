using Application.Interfaces.Repositories;
using Application.Utils;

namespace Application.TaskLists.Commands.UnshareTaskListCommand;

public class UnshareTaskListCommandHandler(ITaskListsRepository repository) : IUnshareTaskListCommandHandler
{
    public async Task<Result<bool>> HandleAsync(UnshareTaskListCommand command)
    {
        var taskList = await repository.GetByIdAsync(command.Id);
        
        if (taskList == null)
            return Result<bool>.Fail($"The tasks list with id: '{command.Id}' was not found.");
        if(!taskList.IsOwnedBy(command.CurrentUserId))
            return Result<bool>.Fail("Can not unshare. You are not the owner of this task list.");
        if(taskList.IsOwnedBy(command.UserId))
            return Result<bool>.Fail("Can not unshare. The task list is owned by the given user.");
        if(!taskList.IsSharedWithUser(command.UserId))
            return Result<bool>.Fail("Can not unshare. The task list is not shared with the given user.");

        taskList.SharedWithUsers.Remove(command.UserId);
        await repository.UpdateAsync(taskList);
        return Result<bool>.Success(true);
    }
}