using Application.Abstractions;
using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.ClassificationAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        //this.Database.SetCommandTimeout(900);
    }


    public DbSet<Partation> Partations { get; set; }
    public DbSet<HadithCollection> HadithCollections { get; set; }
    public DbSet<NarratorStudent> NarratorStudents { get; set; }
    public DbSet<NarratorsCriticism> NarratorsCriticisms { get; set; }
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Bab> Babs { get; set; }
    public DbSet<Hadith> Hadiths { get; set; }
    public DbSet<HadithSharh> HadithSharhs { get; set; }
    public DbSet<HadithTakhreej> HadithTakhreejs { get; set; }
    public DbSet<SharhBook> SharhBooks { get; set; }
    public DbSet<Narrator> Narrators { get; set; }
    public DbSet<NarratorTeacher> NarratorTeachers { get; set; }
    public DbSet<HadithLanguages> HadithLanguages { get; set; }
    public DbSet<HadithTranslations> HadithTranslations { get; set; }

    public DbSet<HadithTranslationsMissing> HadithTranslationsMissings { get; set; }

    public DbSet<HadithMissing> HadithMissings { get; set; }
    public DbSet<HadithTakhreejMessing> HadithTakhreejMessings { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }

    //هيتشال لم الداتا تتصلح
    public DbSet<HadithSharhMissing> hadithSharhMissings { get; set; }
    public DbSet<HadithNarrator> HadithNarrators { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {



        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(AggregateRootEntityBase<int>).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var property = System.Linq.Expressions.Expression.Property(parameter, "IsDeleted");
                var condition = System.Linq.Expressions.Expression.Equal(property, System.Linq.Expressions.Expression.Constant(false));
                var lambda = System.Linq.Expressions.Expression.Lambda(condition, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }






        modelBuilder.Entity<HadithTakhreej>(entity =>
        {
            entity.HasKey(x => new { x.HadithIdFrom, x.HadithIdTo });

            // العلاقة الأولى
            entity.HasOne(x => x.HadithFrom)
                  .WithMany(h => h.TakhreejFrom)
                  .HasForeignKey(x => x.HadithIdFrom)
                  .OnDelete(DeleteBehavior.Restrict);

            // العلاقة الثانية
            entity.HasOne(x => x.HadithTo)
                  .WithMany(h => h.TakhreejTo)
                  .HasForeignKey(x => x.HadithIdTo)
                  .OnDelete(DeleteBehavior.Restrict);
        });


        modelBuilder.Entity<Hadith>()
                .Property(h => h.Id)
                .ValueGeneratedNever();

        modelBuilder.Entity<SharhBook>(entity =>
            {
                entity.HasOne(x => x.Classification)
                      .WithMany(c => c.SharhBook)
                      .HasForeignKey(x => x.ClassificationId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.ClassificationRefrenace)
                          .WithMany()
                          .HasForeignKey(x => x.ClassificationRefrenaceId)
                          .OnDelete(DeleteBehavior.Restrict);

            });



    }
}