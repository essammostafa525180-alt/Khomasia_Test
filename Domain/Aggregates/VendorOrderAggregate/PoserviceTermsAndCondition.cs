using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PoserviceTermsAndCondition : AggregateRootEntityBase<int>
    {
        public int? PoserviceFk { get; set; }
        public int? TermsAndConditionFk { get; set; }
        public string? Description { get; set; }
        public bool IsActive1 { get; set; }
        public TermsAndCondition? TermsAndConditionFkNavigation { get; set; }

        public PoserviceTermsAndCondition()
        {
        }

        public PoserviceTermsAndCondition(int? poserviceFk, int? termsAndConditionFk, string? description, bool isActive1, bool isActive) : this()
        {
            PoserviceFk = poserviceFk;
            TermsAndConditionFk = termsAndConditionFk;
            Description = description;
            IsActive1 = isActive1;
            IsActive = isActive;
        }

        public static PoserviceTermsAndCondition Create(int? poserviceFk, int? termsAndConditionFk, string? description, bool isActive1, bool isActive)
        {

            return new PoserviceTermsAndCondition(poserviceFk, termsAndConditionFk, description, isActive1, isActive);
        }

        public void Update(int? poserviceFk, int? termsAndConditionFk, string? description, bool isActive1, bool isActive)
        {
            PoserviceFk = poserviceFk;
            TermsAndConditionFk = termsAndConditionFk;
            Description = description;
            IsActive1 = isActive1;
            IsActive = isActive;
        }
    }
}
