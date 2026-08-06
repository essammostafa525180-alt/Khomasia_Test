using Domain.Aggregates.CompanyAggregate;
using Domain.Primitives;

namespace Domain.Entities
{
    public class AllowedCompany : AuditableEntityBase<int>
    {
        public int? CompanyFk { get; private set; }
        public int? UserFk { get; private set; }
        public Company? CompanyFkNavigation { get; private set; }

        private AllowedCompany()
        {
        }

        public AllowedCompany(int? companyFk, int? userFk, bool isActive) : this()
        {
            CompanyFk = companyFk;
            UserFk = userFk;
            IsActive = isActive;
        }

        public static AllowedCompany Create(int? companyFk, int? userFk, bool isActive)
        {

            return new AllowedCompany(companyFk, userFk, isActive);
        }

        public void Update(int? companyFk, int? userFk, bool isActive)
        {
            CompanyFk = companyFk;
            UserFk = userFk;
            IsActive = isActive;
        }
    }
}
