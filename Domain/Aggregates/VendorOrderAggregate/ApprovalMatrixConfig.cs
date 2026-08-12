using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class ApprovalMatrixConfig : AggregateRootEntityBase<int>
    {
        public int? ScreenFk { get; set; }
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? ScopeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? LocationFk { get; set; }
        public Company? CompanyFkNavigation { get; set; }
        public Location? LocationFkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }
        public Scope? ScopeFkNavigation { get; set; }
        public ApprovalScreen? ScreenFkNavigation { get; set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

        private List<ApprovalMatrix> _approvalMatrices = new List<ApprovalMatrix>();
        public IReadOnlyCollection<ApprovalMatrix> ApprovalMatrices => _approvalMatrices;

        private List<ApprovalMatrixConfigDetail> _approvalMatrixConfigDetails = new List<ApprovalMatrixConfigDetail>();
        public IReadOnlyCollection<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails => _approvalMatrixConfigDetails;

        public ApprovalMatrixConfig()
        {
        }

        public ApprovalMatrixConfig(int? screenFk, int? companyFk, int? projectFk, int? scopeFk, int? serviceMainCategoryFk, int? locationFk, bool isActive) : this()
        {
            ScreenFk = screenFk;
            CompanyFk = companyFk;
            ProjectFk = projectFk;
            ScopeFk = scopeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            LocationFk = locationFk;
            IsActive = isActive;
        }

        public static ApprovalMatrixConfig Create(int? screenFk, int? companyFk, int? projectFk, int? scopeFk, int? serviceMainCategoryFk, int? locationFk, bool isActive)
        {

            return new ApprovalMatrixConfig(screenFk, companyFk, projectFk, scopeFk, serviceMainCategoryFk, locationFk, isActive);
        }

        public void Update(int? screenFk, int? companyFk, int? projectFk, int? scopeFk, int? serviceMainCategoryFk, int? locationFk, bool isActive)
        {
            ScreenFk = screenFk;
            CompanyFk = companyFk;
            ProjectFk = projectFk;
            ScopeFk = scopeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            LocationFk = locationFk;
            IsActive = isActive;
        }
    }
}
