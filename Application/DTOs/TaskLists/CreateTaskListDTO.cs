using Domain.Entities;

namespace Application.DTOs.TaskLists;

public class CreateTaskListDTO
{
    public required string Name { get; set; }
    public required ICollection<TaskListItem> Tasks { get; set; }
}