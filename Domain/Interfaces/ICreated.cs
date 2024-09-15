namespace Domain.Interfaces;

public interface ICreated
{
    string CreatedByUserId { get; set; }
    DateTime CreatedOnUtc { get; set; }
}