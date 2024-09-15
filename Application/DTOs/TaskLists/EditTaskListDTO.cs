using Domain.Entities;

namespace Application.DTOs.TaskLists;

public class EditTaskListDTO
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<TaskListItem> Tasks { get; set; }
}