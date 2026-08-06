using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ServiceCategory : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? ServiceTypeFk { get; private set; }
        public int? ServiceMainCategoryFk { get; private set; }
        public int? CompanyFk { get; private set; }
        public bool? IsFelKhedma { get; private set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; private set; }
        public ServiceType? ServiceTypeFkNavigation { get; private set; }

        private List<PoserviceDetail> _poserviceDetails = new List<PoserviceDetail>();
        public IReadOnlyCollection<PoserviceDetail> PoserviceDetails => _poserviceDetails;

        private List<ServiceSubCategory> _serviceSubCategories = new List<ServiceSubCategory>();
        public IReadOnlyCollection<ServiceSubCategory> ServiceSubCategories => _serviceSubCategories;

        private List<Service> _services = new List<Service>();
        public IReadOnlyCollection<Service> Services => _services;

        private ServiceCategory()
        {
        }

        public ServiceCategory(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? companyFk, bool? isFelKhedma, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            CompanyFk = companyFk;
            IsFelKhedma = isFelKhedma;
            IsActive = isActive;
        }

        public static ServiceCategory Create(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? companyFk, bool? isFelKhedma, bool isActive)
        {

            return new ServiceCategory(code, name, nameAr, serviceTypeFk, serviceMainCategoryFk, companyFk, isFelKhedma, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? companyFk, bool? isFelKhedma, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            CompanyFk = companyFk;
            IsFelKhedma = isFelKhedma;
            IsActive = isActive;
        }
    }
}
