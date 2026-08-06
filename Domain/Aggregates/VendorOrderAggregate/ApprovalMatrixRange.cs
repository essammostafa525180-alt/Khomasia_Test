using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class ApprovalMatrixRange : AggregateRootEntityBase<int>
    {
        public string? Name { get; set; }
        public decimal? RangeFrom { get; set; }
        public decimal? RangeTo { get; set; }

        private List<ApprovalMatrixConfigDetail> _approvalMatrixConfigDetails = new List<ApprovalMatrixConfigDetail>();
        public IReadOnlyCollection<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails => _approvalMatrixConfigDetails;

        public ApprovalMatrixRange()
        {
        }

        public ApprovalMatrixRange(string? name, decimal? rangeFrom, decimal? rangeTo, bool isActive) : this()
        {
            Name = name;
            RangeFrom = rangeFrom;
            RangeTo = rangeTo;
            IsActive = isActive;
        }

        public static ApprovalMatrixRange Create(string? name, decimal? rangeFrom, decimal? rangeTo, bool isActive)
        {

            return new ApprovalMatrixRange(name, rangeFrom, rangeTo, isActive);
        }

        public void Update(string? name, decimal? rangeFrom, decimal? rangeTo, bool isActive)
        {
            Name = name;
            RangeFrom = rangeFrom;
            RangeTo = rangeTo;
            IsActive = isActive;
        }
    }
}
