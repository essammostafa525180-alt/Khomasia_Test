using Domain.Aggregates.ClassificationAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates.HadithAggregate
{
    public class HadithCollection : AggregateRootEntityBase<int>
    {
        [MaxLength(300)]
        public string? Name { get; set; } = string.Empty;
        public bool MainMenuEnabled { get; set; } = true;

        public int PartationId { get; set; }
        public Partation? Partation { get; set; }

        List<Classification> _classifications = new List<Classification>();
        public IReadOnlyCollection<Classification> Classifications => _classifications;

        public HadithCollection()
        {
        }

        public HadithCollection(string name, bool mainMenuEnabled, int partationId, bool isActive) : this()
        {
            Name = name;
            MainMenuEnabled = mainMenuEnabled;
            PartationId = partationId;
            IsActive = isActive;
        }

        public static HadithCollection Create(string name, bool mainMenuEnabled, int partationId, bool isActive = false)
        {
            return new HadithCollection(name, mainMenuEnabled, partationId, isActive);
        }

        public void Update(string name, bool mainMenuEnabled, int partationId, bool isActive = false)
        {

            Name = name;
            MainMenuEnabled = mainMenuEnabled;
            PartationId = partationId;
            IsActive = isActive;
        }

    }


}
