using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.UnshareTaskListCommand;

public class UnshareTaskListCommand : ICommand
{
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public required string CurrentUserId { get; set; }
}