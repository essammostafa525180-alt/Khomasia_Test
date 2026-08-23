using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CostCenter : AuditableEntityBase<int>
    {

        public int? CompanyID { get; set; }
        public Company Company { get; set; }

        public int? DepartmentID { get; set; }
        public Department Department { get; set; }


        

        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssignCostCenterToSector> _assignCostCenterToSectors = new List<AssignCostCenterToSector>();
        public IReadOnlyCollection<AssignCostCenterToSector> AssignCostCenterToSectors => _assignCostCenterToSectors;

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private CostCenter()
        {
        }

        public CostCenter(int? companyID, int? departmentID, string? code, string? name, string? nameAr, bool isActive) : this()
        {
            CompanyID = companyID;
            DepartmentID = departmentID;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static CostCenter Create(int? companyID, int? departmentID,  string? code, string? name, string? nameAr, bool isActive)
        {

            return new CostCenter(companyID,departmentID, code, name, nameAr, true);    
        }

        public void Update(int? companyID, int? departmentID, string? code, string? name, string? nameAr, bool isActive)
        {
            CompanyID = companyID;
            DepartmentID = departmentID;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
