using Domain.Primitives;

namespace Domain.Aggregates.CompanyAggregate
{
    public class FactoryLine : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int FactoryFk { get; set; }
        public string Name { get; set; }
        public string? NameAr { get; set; }
        public int? Capacity { get; set; }
        public string LineTypes { get; set; }
        public Factory? FactoryFkNavigation { get; set; }

        public FactoryLine()
        {
        }

        public FactoryLine(string? code, string? description, int factoryFk, string name, string? nameAr, int? capacity, string lineTypes, bool isActive) : this()
        {
            Code = code;
            Description = description;
            FactoryFk = factoryFk;
            Name = name;
            NameAr = nameAr;
            Capacity = capacity;
            LineTypes = lineTypes;
            IsActive = isActive;
        }

        public static FactoryLine Create(string? code, string? description, int factoryFk, string name, string? nameAr, int? capacity, string lineTypes, bool isActive)
        {
            Validator.NotNullOrWhiteSpace(name);

            return new FactoryLine(code, description, factoryFk, name, nameAr, capacity, lineTypes, isActive);
        }

        public void Update(string? code, string? description, int factoryFk, string name, string? nameAr, int? capacity, string lineTypes, bool isActive)
        {
            Code = code;
            Description = description;
            FactoryFk = factoryFk;
            Name = name;
            NameAr = nameAr;
            Capacity = capacity;
            LineTypes = lineTypes;
            IsActive = isActive;
        }
    }
}
