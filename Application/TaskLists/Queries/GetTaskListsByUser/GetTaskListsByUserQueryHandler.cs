using Application.Interfaces.Repositories;
using Application.Utils;
using Domain.Entities;

namespace Application.TaskLists.Queries.GetTaskListsByUser;

public class GetTaskListsByUserQueryHandler(ITaskListsRepository repository) : IGetTaskListsByUserQueryHandler
{
    public async Task<Result<IEnumerable<TaskListShortInfo>>> HandleAsync(GetTaskListsByUserQuery query)
    {
        var taskLists = await repository.GetByUserAsync(query);
        return Result<IEnumerable<TaskListShortInfo>>.Success(taskLists);
    }
}