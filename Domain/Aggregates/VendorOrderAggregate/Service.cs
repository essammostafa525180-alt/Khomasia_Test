using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class Service : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? ServiceSubCategoryFk { get; set; }
        public ServiceCategory? ServiceCategoryFkNavigation { get; set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }
        public ServiceSubCategory? ServiceSubCategoryFkNavigation { get; set; }

        private List<PoserviceDetail> _poserviceDetails = new List<PoserviceDetail>();
        public IReadOnlyCollection<PoserviceDetail> PoserviceDetails => _poserviceDetails;

        public Service()
        {
        }

        public Service(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? serviceSubCategoryFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ServiceCategoryFk = serviceCategoryFk;
            ServiceSubCategoryFk = serviceSubCategoryFk;
            IsActive = isActive;
        }

        public static Service Create(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? serviceSubCategoryFk, bool isActive)
        {

            return new Service(code, name, nameAr, serviceTypeFk, serviceMainCategoryFk, serviceCategoryFk, serviceSubCategoryFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? serviceSubCategoryFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ServiceCategoryFk = serviceCategoryFk;
            ServiceSubCategoryFk = serviceSubCategoryFk;
            IsActive = isActive;
        }
    }
}
