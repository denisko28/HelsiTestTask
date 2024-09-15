using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.ShareTaskListCommand;

public class ShareTaskListCommand : ICommand
{
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public required string CurrentUserId { get; set; }
}