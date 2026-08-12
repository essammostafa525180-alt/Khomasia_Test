using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WorkerType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<PoserviceOutsource> _poserviceOutsources = new List<PoserviceOutsource>();
        public IReadOnlyCollection<PoserviceOutsource> PoserviceOutsources => _poserviceOutsources;

        private WorkerType()
        {
        }

        public WorkerType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static WorkerType Create(string? name, string? nameAr, bool isActive)
        {

            return new WorkerType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
