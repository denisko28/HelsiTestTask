namespace Domain.Entities;

public class TaskListShortInfo
{
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedOnUtc { get; set; }
}