using Application.Utils;
using Domain.Interfaces.SQRS.Query;

namespace Application.TaskLists.Queries.GetTaskListSharedWith;

public interface IGetTaskListSharedWithQueryHandler : IQueryHandler<GetTaskListSharedWithQuery, Result<IEnumerable<string>?>>
{
    
}