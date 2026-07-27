using Domain.Aggregates.ClassificationAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.BookAggregate
{
    public class Book : AggregateRootEntityBase<int>
    {
        public string Name { get; set; }
        public int? ClassificationIndex { get; set; }  // ترتيب الكتاب في المصنف بتاعه
        public int? ClassificationId { get; set; }
        public Classification? Classification { get; set; }
        public bool IsAvailable { get; set; } = true; // هل الكتاب ده ظاهر في الموقع ولا لا

        List<Bab> _babs = new List<Bab>();
        public IReadOnlyCollection<Bab> Babs => _babs;

        public int? OldCatId { get; set; } // عشان اعرف اعمل بيهم تقرير عشان اعرف اصلح الداتا 

        public Book()
        {
        }
        public Book(string name, int classificationIndex, int classificationId, bool isAvailable, int oldCatId,
            bool isActive) : this()
        {
            Name = name;
            ClassificationIndex = classificationIndex;
            ClassificationId = classificationId;
            IsAvailable = isAvailable;
            OldCatId = oldCatId;
            IsActive = isActive;
        }

        public static Book Create(string name, int classificationIndex, int classificationId, bool isAvailable,
            int oldCatId, bool isActive = false)
        {
            Validator.NotNullOrWhiteSpace(name);

            return new Book(name, classificationIndex, classificationId, isAvailable, oldCatId, isActive);
        }

        public void Update(string name, int classificationIndex, int classificationId, bool isAvailable, int oldCatId,
            bool isActive = false)
        {
            Name = name;
            ClassificationIndex = classificationIndex;
            ClassificationId = classificationId;
            IsAvailable = isAvailable;
            OldCatId = oldCatId;
            IsActive = isActive;
        }
    }
}


