using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Enums;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates.ClassificationAggregate
{
    /// <summary>
    /// جدول التصنيفات 
    /// </summary>
    public class Classification : AggregateRootEntityBase<int>
    {
        [MaxLength(500)]
        public string? Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? FullName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? CatNameTakhreej { get; set; } = string.Empty;
        public string? Writer { get; set; } = string.Empty;
        public string? FullWriterName { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? WriterDeath { get; set; } = string.Empty;
        public string? AboutBook { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Slug { get; set; } = string.Empty;
        public string? Definition { get; set; } = string.Empty;
        public int? Rank { get; set; }
        public int? BooksNumber { get; set; }
        [MaxLength(300)]
        public string? CoverImage { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Lang { get; set; } = string.Empty;
        public int? StartId { get; set; }
        public int? EndId { get; set; }
        public int? DeathYear { get; set; }

        public ClassificationType Type { get; set; }
        public int? HadithCollectionId { get; set; }
        public HadithCollection? HadithCollection { get; set; }

        public int? Status { get; set; }// صحة المصنف

        List<Book> _books = new List<Book>();
        public IReadOnlyCollection<Book> Books => _books;

        List<SharhBook> _sharhBook = new List<SharhBook>();
        public IReadOnlyCollection<SharhBook> SharhBook => _sharhBook;





        public Classification()
        {
        }
        public Classification(string name, string fullName, string catNameTakhreej, string writer,
            string fullWriterName, string writerDeath, string aboutBook, string slug, string definition,
            int rank, int booksNumber, string coverImage, string lang, int? startId, int? endId, int? deathYear,
            int hadithCollectionId, int status,
            bool isActive) : this()
        {
            Name = name;
            FullName = fullName;
            CatNameTakhreej = catNameTakhreej;
            Writer = writer;
            FullWriterName = fullWriterName;
            WriterDeath = writerDeath;
            AboutBook = aboutBook;
            Slug = slug;
            Definition = definition;
            Rank = rank;
            BooksNumber = booksNumber;
            CoverImage = coverImage;
            Lang = lang;
            StartId = startId;
            EndId = endId;
            DeathYear = deathYear;
            HadithCollectionId = hadithCollectionId;
            Status = status;
            IsActive = isActive;
        }

        public static Classification Create(string name, string fullName, string catNameTakhreej, string writer,
            string fullWriterName, string writerDeath, string aboutBook, string slug, string definition,
            int rank, int booksNumber, string coverImage, string lang, int? startId, int? endId, int? deathYear,
            int HadithCollectionId, int status, bool isActive)
        {
            return new Classification(name, fullName, catNameTakhreej, writer, fullWriterName, writerDeath,
               aboutBook, slug, definition, rank, booksNumber, coverImage, lang
               , startId, endId, deathYear, HadithCollectionId, status, isActive);
        }

        public void Update(string name, string fullName, string catNameTakhreej, string writer,
            string fullWriterName, string writerDeath, string aboutBook, string slug, string definition,
            int rank, int booksNumber, string coverImage, string lang, int? startId, int? endId, int? deathYear,
            int hadithCollectionId, int status, bool isActive = false)
        {

            Name = name;
            FullName = fullName;
            CatNameTakhreej = catNameTakhreej;
            Writer = writer;
            FullWriterName = fullWriterName;
            WriterDeath = writerDeath;
            AboutBook = aboutBook;
            Slug = slug;
            Definition = definition;
            Rank = rank;
            BooksNumber = booksNumber;
            CoverImage = coverImage;
            Lang = lang;
            StartId = startId;
            EndId = endId;
            DeathYear = deathYear;
            HadithCollectionId = hadithCollectionId;
            Status = status;
            IsActive = isActive;
        }
    }

}
