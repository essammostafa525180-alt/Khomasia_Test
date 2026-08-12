using Domain.Aggregates.PdaAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Pdadetail> _pdadetails = new List<Pdadetail>();
        public IReadOnlyCollection<Pdadetail> Pdadetails => _pdadetails;

        private List<State> _states = new List<State>();
        public IReadOnlyCollection<State> States => _states;

        private Country()
        {
        }

        public Country(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Country Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new Country(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
