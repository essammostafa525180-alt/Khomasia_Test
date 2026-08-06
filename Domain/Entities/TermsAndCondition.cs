using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TermsAndCondition : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<PoserviceTermsAndCondition> _poserviceTermsAndConditions = new List<PoserviceTermsAndCondition>();
        public IReadOnlyCollection<PoserviceTermsAndCondition> PoserviceTermsAndConditions => _poserviceTermsAndConditions;

        private TermsAndCondition()
        {
        }

        public TermsAndCondition(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static TermsAndCondition Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new TermsAndCondition(code, name, nameAr, isActive);
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
