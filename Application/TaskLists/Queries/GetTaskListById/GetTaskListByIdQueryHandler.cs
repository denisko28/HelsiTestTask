using Application.Interfaces.Repositories;
using Application.Utils;
using Domain.Entities;

namespace Application.TaskLists.Queries.GetTaskListById;

public class GetTaskListByIdQueryHandler(ITaskListsRepository repository) : IGetTaskListByIdQueryHandler
{
    public async Task<Result<TaskList?>> HandleAsync(GetTaskListByIdQuery query)
    {
        var taskList = await repository.GetByIdAsync(query.Id);
        
        if (taskList == null)
            return Result<TaskList>.Fail($"The tasks list with id: '{query.Id}' was not found.");
        if(!taskList.IsAccessibleByUser(query.CurrentUserId))
            return Result<TaskList>.Fail("You don't have access to this task list.");
        
        return Result<TaskList?>.Success(taskList);
    }
}