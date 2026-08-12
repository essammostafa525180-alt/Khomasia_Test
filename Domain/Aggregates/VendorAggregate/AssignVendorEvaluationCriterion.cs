using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorAggregate
{
    public class AssignVendorEvaluationCriterion : AggregateRootEntityBase<int>
    {
        public int? VendorFk { get; set; }
        public int? VendorEvaluationCriteriaFk { get; set; }
        public int? RankFk { get; set; }
        public Rank? RankFkNavigation { get; set; }
        public VendorEvaluationCriterion? VendorEvaluationCriteriaFkNavigation { get; set; }
        public Vendor? VendorFkNavigation { get; set; }

        public AssignVendorEvaluationCriterion()
        {
        }

        public AssignVendorEvaluationCriterion(int? vendorFk, int? vendorEvaluationCriteriaFk, int? rankFk, bool isActive) : this()
        {
            VendorFk = vendorFk;
            VendorEvaluationCriteriaFk = vendorEvaluationCriteriaFk;
            RankFk = rankFk;
            IsActive = isActive;
        }

        public static AssignVendorEvaluationCriterion Create(int? vendorFk, int? vendorEvaluationCriteriaFk, int? rankFk, bool isActive)
        {

            return new AssignVendorEvaluationCriterion(vendorFk, vendorEvaluationCriteriaFk, rankFk, isActive);
        }

        public void Update(int? vendorFk, int? vendorEvaluationCriteriaFk, int? rankFk, bool isActive)
        {
            VendorFk = vendorFk;
            VendorEvaluationCriteriaFk = vendorEvaluationCriteriaFk;
            RankFk = rankFk;
            IsActive = isActive;
        }
    }
}
