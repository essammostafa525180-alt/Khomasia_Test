using Domain.Abstractions;
using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.ClassificationAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Entities;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;



    public IRepository<Partation, int> PartitionRepository { get; set; }
    public IRepository<HadithCollection, int> HadithCollectionRepository { get; set; }
    public IRepository<Classification, int> ClassificationRepository { get; set; }
    public IRepository<HadithTakhreej, int> HadithTakhreejRepository { get; set; }

    public IRepository<Hadith, int> HadithRepository { get; set; }
    // هتتشال قدام لم الداتا تتصلح
    public IRepository<HadithMissing, int> HadithMissingRepository { get; set; }

    public IRepository<HadithTranslations, int> HadithTranslationRepository { get; set; }

    public IRepository<HadithSharh, int> HadithSharhRepository { get; set; }
    public IRepository<Bab, int> BabRepository { get; set; }
    public IRepository<Book, int> BookRepository { get; set; }
    public IRepository<Narrator, int> NarratorRepository { get; set; }
    public IRepository<SharhBook, int> SharhBookRepository { get; set; }
    public IRepository<ContactMessage, int> ContactMessageRepository { get; set; }

    public IRepository<HadithSharhMissing, int> HadithSharhMissingRepository { get; set; }


    public UnitOfWork(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
        PartitionRepository = new Repository<Partation, int>(context);
        HadithCollectionRepository = new Repository<HadithCollection, int>(context);
        ClassificationRepository = new Repository<Classification, int>(context);
        HadithRepository = new Repository<Hadith, int>(context);
        // هتتشال قدام لم الداتا تتصلح
        HadithMissingRepository = new Repository<HadithMissing, int>(context);
        HadithSharhMissingRepository = new Repository<HadithSharhMissing, int>(context);
        HadithSharhRepository = new Repository<HadithSharh, int>(context);
        BabRepository = new Repository<Bab, int>(context);
        BookRepository = new Repository<Book, int>(context);
        NarratorRepository = new Repository<Narrator, int>(context);
        SharhBookRepository = new Repository<SharhBook, int>(context);
        HadithTranslationRepository = new Repository<HadithTranslations, int>(context);
        HadithTakhreejRepository = new Repository<HadithTakhreej, int>(context);
        ContactMessageRepository = new Repository<ContactMessage, int>(context);
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in _context.ChangeTracker.Entries<AuditableEntityBase<Guid>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "System";
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            else if (entry.State == EntityState.Modified && entry.Entity.IsDeleted)
            {
                entry.Entity.DeletedBy = "System";
                entry.Entity.DeletedAt = DateTime.UtcNow;
            }
            else
            {
                entry.Entity.ModifiedBy = "System";
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {

        try
        {
            // Start a transaction to ensure both saving and event dispatching happen atomically
            return await CreateExecutionStrategy(async () =>
            {
                // Dispatch the domain events before saving changes
                await DispatchDomainEvents(_context).ConfigureAwait(false);

                // Now save the changes
                var result = await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return result > 0;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            throw;
        }
    }
    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;

        var entities = context.ChangeTracker
            .Entries<AggregateRootEntityBase<Guid>>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent);
    }
    private async Task<bool> CreateExecutionStrategy(Func<Task<bool>> action, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var result = await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken)
            .ConfigureAwait(false);
            var result = await action();
            await transaction.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
            return result;
        });
        return result;
    }
}


public class UnitOfWork<TEntity, TId> : IUnitOfWork<TEntity, TId>, IDisposable
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public IRepository<TEntity, TId> Repository { get; set; }

    public UnitOfWork(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
        Repository = new Repository<TEntity, TId>(context);
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in _context.ChangeTracker.Entries<AuditableEntityBase<Guid>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "System";
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            else if (entry.State == EntityState.Modified && entry.Entity.IsDeleted)
            {
                entry.Entity.DeletedBy = "System";
                entry.Entity.DeletedAt = DateTime.UtcNow;
            }
            else
            {
                entry.Entity.ModifiedBy = "System";
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {

        try
        {
            // Start a transaction to ensure both saving and event dispatching happen atomically
            return await CreateExecutionStrategy(async () =>
            {
                // Dispatch the domain events before saving changes
                await DispatchDomainEvents(_context).ConfigureAwait(false);

                // Now save the changes
                var result = await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return result > 0;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            throw;
        }
    }
    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;

        var entities = context.ChangeTracker
            .Entries<AggregateRootEntityBase<Guid>>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent);
    }
    private async Task<bool> CreateExecutionStrategy(Func<Task<bool>> action, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var result = await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken)
            .ConfigureAwait(false);
            var result = await action();
            await transaction.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
            return result;
        });

        return result;
    }
}
