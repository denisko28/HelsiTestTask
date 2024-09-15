using Domain.Interfaces;

namespace Domain.Entities;

public class TaskList : ICreated
{
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<TaskListItem> Tasks { get; set; } = [];
    public HashSet<string> SharedWithUsers { get; set; } = [];
    public string CreatedByUserId { get; set; } = null!;
    public DateTime CreatedOnUtc { get; set; }

    public bool IsOwnedBy(string userId) => CreatedByUserId == userId;

    public bool IsSharedWithUser(string userId) => SharedWithUsers.Contains(userId);

    public bool IsAccessibleByUser(string userId) => IsOwnedBy(userId) || IsSharedWithUser(userId);
}