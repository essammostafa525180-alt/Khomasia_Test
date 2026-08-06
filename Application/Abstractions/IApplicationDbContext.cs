

using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.ClassificationAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Entities;
using Domain.Entities.Legacy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Abstractions;
public interface IApplicationDbContext
{
    DatabaseFacade Database { get; }
    DbSet<_20230515CairoOpeningBalance> _20230515CairoOpeningBalances { get; set; }
    DbSet<_20230515HebaOpeningBalance> _20230515HebaOpeningBalances { get; set; }
    DbSet<Cairo202320240721> Cairo202320240721s { get; set; }
    DbSet<Cairo202320240721merge> Cairo202320240721merges { get; set; }
    DbSet<Cairo2024> Cairo2024s { get; set; }
    DbSet<CairoAvgcost20240729> CairoAvgcost20240729s { get; set; }
    DbSet<DataMergeItem> DataMergeItems { get; set; }
    DbSet<Heba202320240721> Heba202320240721s { get; set; }
    DbSet<Heba202320240721merge> Heba202320240721merges { get; set; }
    DbSet<Heba2024> Heba2024s { get; set; }
    DbSet<HebaAvgcost20240729> HebaAvgcost20240729s { get; set; }
    DbSet<InventoryItem2024> InventoryItem2024s { get; set; }
    DbSet<InventoryItemLocation20230404> InventoryItemLocation20230404s { get; set; }
    DbSet<InventoryItemLocation20230505> InventoryItemLocation20230505s { get; set; }
    DbSet<InventoryItemLocation20240723> InventoryItemLocation20240723s { get; set; }
    DbSet<InventoryItemLocationDetail20240723> InventoryItemLocationDetail20240723s { get; set; }
    DbSet<InventoryItemMerge20240522> InventoryItemMerge20240522s { get; set; }
    DbSet<InventoryItemMerge20240610> InventoryItemMerge20240610s { get; set; }
    DbSet<MmItemsForMerge2> MmItemsForMerge2s { get; set; }
    DbSet<MotorodItem> MotorodItems { get; set; }
    DbSet<NotFoundItem> NotFoundItems { get; set; }
    DbSet<PoChangeVehicle20240331> PoChangeVehicle20240331s { get; set; }
    DbSet<ProcDatum> ProcData { get; set; }
    DbSet<Sheet1> Sheet1s { get; set; }
    DbSet<StockCount20230331> StockCount20230331s { get; set; }
    DbSet<Temp> Temps { get; set; }
    DbSet<TempBatch> TempBatches { get; set; }
    //public DbSet<Partation> Partations { get; set; }
    //public DbSet<HadithCollection> HadithCollections { get; set; }
    //public DbSet<NarratorStudent> NarratorStudents { get; set; }
    //public DbSet<NarratorsCriticism> NarratorsCriticisms { get; set; }
    //public DbSet<Classification> Classifications { get; set; }
    //public DbSet<Book> Books { get; set; }
    //public DbSet<Bab> Babs { get; set; }
    //public DbSet<Hadith> Hadiths { get; set; }
    //public DbSet<HadithTakhreejMessing> HadithTakhreejMessings { get; set; }
    //public DbSet<HadithSharh> HadithSharhs { get; set; }
    //public DbSet<HadithTakhreej> HadithTakhreejs { get; set; }
    //public DbSet<SharhBook> SharhBooks { get; set; }
    //public DbSet<Narrator> Narrators { get; set; }
    //public DbSet<NarratorTeacher> NarratorTeachers { get; set; }
    //public DbSet<HadithLanguages> HadithLanguages { get; set; }
    //public DbSet<HadithTranslations> HadithTranslations { get; set; }
    //public DbSet<HadithTranslationsMissing> HadithTranslationsMissings { get; set; }
    //public DbSet<HadithMissing> HadithMissings { get; set; }
    ////هيتشال لم الداتا تتصلح
    //public DbSet<HadithSharhMissing> hadithSharhMissings { get; set; }
    //public DbSet<HadithNarrator> HadithNarrators { get; set; }

    //public DbSet<ContactMessage> ContactMessages { get; set; }



}
