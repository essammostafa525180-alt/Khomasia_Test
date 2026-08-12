using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.CompanyAggregate
{
    public class Factory : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string Name { get; set; }
        public string? NameAr { get; set; }

        private List<FactoryLine> _factoryLines = new List<FactoryLine>();
        public IReadOnlyCollection<FactoryLine> FactoryLines => _factoryLines;

        public Factory()
        {
        }

        public Factory(string? code, string? description, string? address, string name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Description = description;
            Address = address;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Factory Create(string? code, string? description, string? address, string name, string? nameAr, bool isActive)
        {
            Validator.NotNullOrWhiteSpace(name);

            return new Factory(code, description, address, name, nameAr, isActive);
        }

        public void Update(string? code, string? description, string? address, string name, string? nameAr, bool isActive)
        {
            Code = code;
            Description = description;
            Address = address;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
