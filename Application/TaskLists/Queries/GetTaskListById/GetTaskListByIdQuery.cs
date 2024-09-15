using Domain.Interfaces.SQRS.Query;

namespace Application.TaskLists.Queries.GetTaskListById;

public class GetTaskListByIdQuery : IQuery
{
    public required string Id { get; set; }
    public required string CurrentUserId { get; set; }
}