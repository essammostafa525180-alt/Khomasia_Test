

using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.ClassificationAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Abstractions;
public interface IApplicationDbContext
{
    DatabaseFacade Database { get; }
    public DbSet<Partation> Partations { get; set; }
    public DbSet<HadithCollection> HadithCollections { get; set; }
    public DbSet<NarratorStudent> NarratorStudents { get; set; }
    public DbSet<NarratorsCriticism> NarratorsCriticisms { get; set; }
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Bab> Babs { get; set; }
    public DbSet<Hadith> Hadiths { get; set; }
    public DbSet<HadithTakhreejMessing> HadithTakhreejMessings { get; set; }
    public DbSet<HadithSharh> HadithSharhs { get; set; }
    public DbSet<HadithTakhreej> HadithTakhreejs { get; set; }
    public DbSet<SharhBook> SharhBooks { get; set; }
    public DbSet<Narrator> Narrators { get; set; }
    public DbSet<NarratorTeacher> NarratorTeachers { get; set; }
    public DbSet<HadithLanguages> HadithLanguages { get; set; }
    public DbSet<HadithTranslations> HadithTranslations { get; set; }
    public DbSet<HadithTranslationsMissing> HadithTranslationsMissings { get; set; }
    public DbSet<HadithMissing> HadithMissings { get; set; }
    //هيتشال لم الداتا تتصلح
    public DbSet<HadithSharhMissing> hadithSharhMissings { get; set; }
    public DbSet<HadithNarrator> HadithNarrators { get; set; }

    public DbSet<ContactMessage> ContactMessages { get; set; }



}
