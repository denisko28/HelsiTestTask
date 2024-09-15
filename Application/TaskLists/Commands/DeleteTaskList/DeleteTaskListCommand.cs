using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.DeleteTaskList;

public class DeleteTaskListCommand : ICommand
{
    public required string Id { get; set; } 
    public required string CurrentUserId { get; set; }
}