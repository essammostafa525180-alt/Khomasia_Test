using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class State : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? CountryFk { get; private set; }
        public Country? CountryFkNavigation { get; private set; }

        private List<City> _cities = new List<City>();
        public IReadOnlyCollection<City> Cities => _cities;

        private State()
        {
        }

        public State(string? code, string? name, string? nameAr, int? countryFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            CountryFk = countryFk;
            IsActive = isActive;
        }

        public static State Create(string? code, string? name, string? nameAr, int? countryFk, bool isActive)
        {

            return new State(code, name, nameAr, countryFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? countryFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            CountryFk = countryFk;
            IsActive = isActive;
        }
    }
}
