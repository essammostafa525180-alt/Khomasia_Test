using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.PdaAggregate
{
    public class Pdamodel : AggregateRootEntityBase<int>
    {
        public string? Name { get; set; }
        public string? NameAr { get; set; }

        private List<Pdadetail> _pdadetails = new List<Pdadetail>();
        public IReadOnlyCollection<Pdadetail> Pdadetails => _pdadetails;

        public Pdamodel()
        {
        }

        public Pdamodel(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Pdamodel Create(string? name, string? nameAr, bool isActive)
        {

            return new Pdamodel(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
