using Application.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public sealed class ApplicationDbContext : DbContext
{
    private IDateTimeService _DateTimeService;
    public ApplicationDbContext(DbContextOptions options, IDateTimeService dateTimeService) : base(options)
    {
        // this is for make EF not track a entity
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // this is for get the current UTC dateTime from the service
        _DateTimeService = dateTimeService;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        // this foreach is for update the Created and lastModified props in all the entities that inherit from AuditableBaseEntity when they save the changes
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _DateTimeService.NowUtc;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _DateTimeService.NowUtc;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}