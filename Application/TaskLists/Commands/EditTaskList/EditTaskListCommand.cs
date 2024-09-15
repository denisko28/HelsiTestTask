using Domain.Entities;
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.EditTaskList;

public class EditTaskListCommand : ICommand
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required ICollection<TaskListItem> Tasks { get; set; }
    public required string CurrentUserId { get; set; } = null!;
}