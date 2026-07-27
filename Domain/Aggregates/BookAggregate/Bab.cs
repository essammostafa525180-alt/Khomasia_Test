using Domain.Aggregates.HadithAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.BookAggregate
{
    /// <summary>
    /// refered to bab at old DB 
    /// </summary>
    public class Bab : AggregateRootEntityBase<int>
    {
        public string Name { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
        public int? BabIndex { get; private set; }
        public bool IsAvailable { get; set; } = true;

        private List<Hadith> _hadiths = new List<Hadith>();
        public IReadOnlyCollection<Hadith> Hadiths => _hadiths;

        private List<HadithTakhreej> _hadithTakhreej = new List<HadithTakhreej>();
        public IReadOnlyCollection<HadithTakhreej> HadithTakhreej => _hadithTakhreej;

        public Bab()
        {
        }
        public Bab(string name, int bookId, int babIndex, bool isAvailable, bool isActive) : this()
        {
            Name = name;
            BookId = bookId;
            BabIndex = babIndex;
            IsAvailable = isAvailable;
            IsActive = isActive;
        }

        public static Bab Create(string name, int bookId, int babIndex, bool isAvailable, bool isActive)
        {
            Validator.NotNullOrWhiteSpace(name);

            return new Bab(name, bookId, babIndex, isAvailable, isActive);
        }

        public void Update(string name, int bookId, int babIndex, bool isAvailable, bool isActive)
        {
            Name = name;
            BookId = bookId;
            BabIndex = babIndex;
            IsAvailable = isAvailable;
            IsActive = isActive;
        }
    }
}
