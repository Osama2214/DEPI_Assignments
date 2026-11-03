using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LibraryApi.Data.Interceptors;

public class CreatedAtInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
    {
        Apply(eventData.Context);
        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        Apply(eventData.Context);
        return ValueTask.FromResult(result);
    }

    private static void Apply(DbContext? context)
    {
        if (context == null)
            return;

        var now = DateTime.UtcNow;
        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>()
                     .Where(entry => entry.State == EntityState.Added).ToList())
        {
            entry.Entity.CreatedAt = now;
            entry.Entity.ModifiedAt = now;
        }
    }
}
