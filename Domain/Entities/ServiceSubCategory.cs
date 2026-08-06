using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ServiceSubCategory : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? ServiceTypeFk { get; private set; }
        public int? ServiceMainCategoryFk { get; private set; }
        public int? ServiceCategoryFk { get; private set; }
        public int? CompanyFk { get; private set; }
        public ServiceCategory? ServiceCategoryFkNavigation { get; private set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; private set; }
        public ServiceType? ServiceTypeFkNavigation { get; private set; }

        private List<PoserviceDetail> _poserviceDetails = new List<PoserviceDetail>();
        public IReadOnlyCollection<PoserviceDetail> PoserviceDetails => _poserviceDetails;

        private List<Service> _services = new List<Service>();
        public IReadOnlyCollection<Service> Services => _services;

        private ServiceSubCategory()
        {
        }

        public ServiceSubCategory(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? companyFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ServiceCategoryFk = serviceCategoryFk;
            CompanyFk = companyFk;
            IsActive = isActive;
        }

        public static ServiceSubCategory Create(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? companyFk, bool isActive)
        {

            return new ServiceSubCategory(code, name, nameAr, serviceTypeFk, serviceMainCategoryFk, serviceCategoryFk, companyFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? companyFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ServiceCategoryFk = serviceCategoryFk;
            CompanyFk = companyFk;
            IsActive = isActive;
        }
    }
}
