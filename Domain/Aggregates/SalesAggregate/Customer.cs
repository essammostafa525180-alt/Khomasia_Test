using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SalesAggregate
{
    public class Customer : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public string? CommercialRecord { get; set; }
        public string? OtherVendor { get; set; }
        public int? CompanyFk { get; set; }
        public int? SectorFk { get; set; }

        private List<SalesInvoice> _salesInvoices = new List<SalesInvoice>();
        public IReadOnlyCollection<SalesInvoice> SalesInvoices => _salesInvoices;

        private List<SalesQuotation> _salesQuotations = new List<SalesQuotation>();
        public IReadOnlyCollection<SalesQuotation> SalesQuotations => _salesQuotations;

        private List<Visit> _visits = new List<Visit>();
        public IReadOnlyCollection<Visit> Visits => _visits;

        public Customer()
        {
        }

        public Customer(string? code, string? name, string? nameAr, string? phone, string? address, string? contactPerson, string? commercialRecord, string? otherVendor, int? companyFk, int? sectorFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Phone = phone;
            Address = address;
            ContactPerson = contactPerson;
            CommercialRecord = commercialRecord;
            OtherVendor = otherVendor;
            CompanyFk = companyFk;
            SectorFk = sectorFk;
            IsActive = isActive;
        }

        public static Customer Create(string? code, string? name, string? nameAr, string? phone, string? address, string? contactPerson, string? commercialRecord, string? otherVendor, int? companyFk, int? sectorFk, bool isActive)
        {

            return new Customer(code, name, nameAr, phone, address, contactPerson, commercialRecord, otherVendor, companyFk, sectorFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, string? phone, string? address, string? contactPerson, string? commercialRecord, string? otherVendor, int? companyFk, int? sectorFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Phone = phone;
            Address = address;
            ContactPerson = contactPerson;
            CommercialRecord = commercialRecord;
            OtherVendor = otherVendor;
            CompanyFk = companyFk;
            SectorFk = sectorFk;
            IsActive = isActive;
        }
    }
}
