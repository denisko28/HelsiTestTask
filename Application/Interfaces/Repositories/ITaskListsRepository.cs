using Application.TaskLists.Queries.GetTaskListsByUser;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITaskListsRepository
{
    Task<IEnumerable<TaskListShortInfo>> GetByUserAsync(GetTaskListsByUserQuery query);

    Task<TaskList?> GetByIdAsync(string id);

    Task AddAsync(TaskList taskList);

    Task UpdateAsync(TaskList taskList);

    Task DeleteAsync(string id);
}