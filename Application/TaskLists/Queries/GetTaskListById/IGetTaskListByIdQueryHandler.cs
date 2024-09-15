using Application.Utils;
using Domain.Entities;
using Domain.Interfaces.SQRS.Query;

namespace Application.TaskLists.Queries.GetTaskListById;

public interface IGetTaskListByIdQueryHandler : IQueryHandler<GetTaskListByIdQuery, Result<TaskList?>>
{
    
}