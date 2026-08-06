using Domain.Aggregates.UserAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class EmployeeJob : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? EmployeeJobFk { get; private set; }

        private List<Employee> _employees = new List<Employee>();
        public IReadOnlyCollection<Employee> Employees => _employees;

        private List<PoserviceOutsource> _poserviceOutsources = new List<PoserviceOutsource>();
        public IReadOnlyCollection<PoserviceOutsource> PoserviceOutsources => _poserviceOutsources;

        private List<PoserviceRecomendedResource> _poserviceRecomendedResources = new List<PoserviceRecomendedResource>();
        public IReadOnlyCollection<PoserviceRecomendedResource> PoserviceRecomendedResources => _poserviceRecomendedResources;

        private EmployeeJob()
        {
        }

        public EmployeeJob(string? code, string? name, string? nameAr, int? employeeJobFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            EmployeeJobFk = employeeJobFk;
            IsActive = isActive;
        }

        public static EmployeeJob Create(string? code, string? name, string? nameAr, int? employeeJobFk, bool isActive)
        {

            return new EmployeeJob(code, name, nameAr, employeeJobFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? employeeJobFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            EmployeeJobFk = employeeJobFk;
            IsActive = isActive;
        }
    }
}
