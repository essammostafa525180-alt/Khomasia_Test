using Domain.Aggregates.ClassificationAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.BookSharhAggregate
{
    public class SharhBook : AggregateRootEntityBase<int>
    {
        public string Name { get; set; }
        public int? ClassificationId { get; set; }

        public Classification? Classification { get; set; }
        public int? ClassificationRefrenaceId { get; set; }
        public Classification? ClassificationRefrenace { get; set; }



        List<HadithSharh> _hadithSharhs = new List<HadithSharh>();
        public IReadOnlyCollection<HadithSharh> HadithSharhs => _hadithSharhs;


        public SharhBook()
        {
        }
        public SharhBook(string name, int classificationId,
            bool isActive) : this()
        {
            Name = name;
            ClassificationId = classificationId;
            IsActive = isActive;

        }

        public static SharhBook Create(string name, int classificationId, string coverImage,
             bool isActive = false)
        {
            Validator.NotNullOrWhiteSpace(name);

            return new SharhBook(name, classificationId, isActive);
        }

        public void Update(string name, int classificationId,
            bool isActive = false)
        {
            Name = name;
            ClassificationId = classificationId;
            IsActive = isActive;
        }
    }
}
