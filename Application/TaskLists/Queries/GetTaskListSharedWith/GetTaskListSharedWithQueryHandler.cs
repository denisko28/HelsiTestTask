using Application.Interfaces.Repositories;
using Application.TaskLists.Queries.GetTaskListsByUser;
using Application.Utils;
using Domain.Entities;

namespace Application.TaskLists.Queries.GetTaskListSharedWith;

public class GetTaskListSharedWithQueryHandler(ITaskListsRepository repository) : IGetTaskListSharedWithQueryHandler
{
    public async Task<Result<IEnumerable<string>?>> HandleAsync(GetTaskListSharedWithQuery query)
    {
        var taskList = await repository.GetByIdAsync(query.Id);
        
        if (taskList == null)
            return Result<IEnumerable<string>>.Fail($"The tasks list with id: '{query.Id}' was not found.");
        if(!taskList.IsAccessibleByUser(query.CurrentUserId))
            return Result<IEnumerable<string>>.Fail("You don't have access to this task list.");
        
        return Result<IEnumerable<string>?>.Success(taskList.SharedWithUsers);
    }
}