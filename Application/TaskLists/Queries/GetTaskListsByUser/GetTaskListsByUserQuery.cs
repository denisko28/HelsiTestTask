using Application.Utils.SortingPagination;
using Domain.Interfaces.SQRS.Query;

namespace Application.TaskLists.Queries.GetTaskListsByUser;

public class GetTaskListsByUserQuery : SortingPaginationModel, IQuery
{
    public required string CurrentUserId { get; set; }
}