using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.ClassificationAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Entities;


namespace Domain.Abstractions;
public interface IUnitOfWork
{


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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

}

public interface IUnitOfWork<TEntity, TId>
{
    public IRepository<TEntity, TId> Repository { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
