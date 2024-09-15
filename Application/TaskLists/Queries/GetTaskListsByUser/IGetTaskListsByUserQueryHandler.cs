using Application.Utils;
using Domain.Entities;
using Domain.Interfaces.SQRS.Query;

namespace Application.TaskLists.Queries.GetTaskListsByUser;

public interface IGetTaskListsByUserQueryHandler : IQueryHandler<GetTaskListsByUserQuery, Result<IEnumerable<TaskListShortInfo>>>
{
    
}