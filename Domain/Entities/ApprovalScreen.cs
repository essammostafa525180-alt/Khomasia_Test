using Domain.Aggregates.UserAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ApprovalScreen : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<ApprovalMatrix> _approvalMatrices = new List<ApprovalMatrix>();
        public IReadOnlyCollection<ApprovalMatrix> ApprovalMatrices => _approvalMatrices;

        private List<ApprovalMatrixConfig> _approvalMatrixConfigs = new List<ApprovalMatrixConfig>();
        public IReadOnlyCollection<ApprovalMatrixConfig> ApprovalMatrixConfigs => _approvalMatrixConfigs;

        private List<Pruser> _prusers = new List<Pruser>();
        public IReadOnlyCollection<Pruser> Prusers => _prusers;

        private ApprovalScreen()
        {
        }

        public ApprovalScreen(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ApprovalScreen Create(string? name, string? nameAr, bool isActive)
        {

            return new ApprovalScreen(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
