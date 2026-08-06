using Domain.Primitives;

namespace Domain.Aggregates.CompanyAggregate
{
    public class Expense : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CompanyFk { get; set; }

        public Expense()
        {
        }

        public Expense(string? code, string? name, string? nameAr, int? companyFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            CompanyFk = companyFk;
            IsActive = isActive;
        }

        public static Expense Create(string? code, string? name, string? nameAr, int? companyFk, bool isActive)
        {

            return new Expense(code, name, nameAr, companyFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? companyFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            CompanyFk = companyFk;
            IsActive = isActive;
        }
    }
}
