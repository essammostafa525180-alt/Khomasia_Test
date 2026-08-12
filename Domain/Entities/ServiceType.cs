using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ServiceType : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<PoserviceDetail> _poserviceDetails = new List<PoserviceDetail>();
        public IReadOnlyCollection<PoserviceDetail> PoserviceDetails => _poserviceDetails;

        private List<ServiceCategory> _serviceCategories = new List<ServiceCategory>();
        public IReadOnlyCollection<ServiceCategory> ServiceCategories => _serviceCategories;

        private List<ServiceSubCategory> _serviceSubCategories = new List<ServiceSubCategory>();
        public IReadOnlyCollection<ServiceSubCategory> ServiceSubCategories => _serviceSubCategories;

        private ServiceType()
        {
        }

        public ServiceType(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ServiceType Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new ServiceType(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
