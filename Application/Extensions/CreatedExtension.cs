using Domain.Interfaces;

namespace Application.Extensions;

public static class CreatedExtension
{
    public static void RegisterCreation(this ICreated createdBy, string userId)
    {
        createdBy.CreatedByUserId = userId;
        createdBy.CreatedOnUtc = DateTime.UtcNow;
    }
}