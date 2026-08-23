using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class InventoryCurrency : AuditableEntityBase<int>
    {

        public string? Code { get; set; }
        public string? Symbol { get; set; }
        public short? Precision { get; set; }


        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private InventoryCurrency()
        {
        }

        public InventoryCurrency(string? code , string? symbol, short? precision, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Symbol = symbol;
            Precision = precision;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static InventoryCurrency Create(string? code, string? symbol, short? precision, string? name, string? nameAr, bool isActive)
        {

            return new InventoryCurrency(code, symbol, precision, name, nameAr, isActive);
        }

        public void Update(string? code, string? symbol, short? precision, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Symbol = symbol;
            Precision = precision; 
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
