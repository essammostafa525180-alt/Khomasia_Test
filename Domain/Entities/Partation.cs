using Domain.Aggregates.HadithAggregate;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Partation : AuditableEntityBase<int>
    {
        [MaxLength(100)]
        public string Name { get; private set; } = string.Empty;

        public bool HasCollection { get; private set; }

        private List<HadithCollection> _hadithCollections = new List<HadithCollection>();
        public IReadOnlyCollection<HadithCollection> HadithCollections => _hadithCollections;

        private Partation()
        {
        }

        public Partation(string name, bool hasCollection, bool isActive = false)
        : this()
        {
            Name = name;
            HasCollection = hasCollection;
            IsActive = isActive;
        }

        public static Partation Create(string name, bool hasCollection, bool isActive = true)
        {
            return new Partation(name, hasCollection, isActive);
        }

        public void Update(string name, bool hasCollection, bool isActive = true)
        {
            Name = name;
            HasCollection = hasCollection;
            IsActive = isActive;
        }
    }




}
