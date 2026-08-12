using Domain.Aggregates.VendorAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VendorEvaluationCriterion : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssignVendorEvaluationCriterion> _assignVendorEvaluationCriteria = new List<AssignVendorEvaluationCriterion>();
        public IReadOnlyCollection<AssignVendorEvaluationCriterion> AssignVendorEvaluationCriteria => _assignVendorEvaluationCriteria;

        private VendorEvaluationCriterion()
        {
        }

        public VendorEvaluationCriterion(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static VendorEvaluationCriterion Create(string? name, string? nameAr, bool isActive)
        {

            return new VendorEvaluationCriterion(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
