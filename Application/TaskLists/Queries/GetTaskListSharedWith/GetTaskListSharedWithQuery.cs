using Domain.Interfaces.SQRS.Query;

namespace Application.TaskLists.Queries.GetTaskListSharedWith;

public class GetTaskListSharedWithQuery : IQuery
{
    public required string Id { get; set; }
    public required string CurrentUserId { get; set; }
}