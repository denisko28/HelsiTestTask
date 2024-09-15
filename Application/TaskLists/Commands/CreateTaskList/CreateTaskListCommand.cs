using Domain.Entities;
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.CreateTaskList;

public class CreateTaskListCommand : ICommand
{
    public required string Name { get; set; }
    public ICollection<TaskListItem> Tasks { get; set; } = [];
    public required string CurrentUserId { get; set; }
}