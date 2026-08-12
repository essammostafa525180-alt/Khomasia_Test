using Domain.Aggregates.RequestAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class RequestLineItemStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventroyItemRequestWithdrawDetail> _inventroyItemRequestWithdrawDetails = new List<InventroyItemRequestWithdrawDetail>();
        public IReadOnlyCollection<InventroyItemRequestWithdrawDetail> InventroyItemRequestWithdrawDetails => _inventroyItemRequestWithdrawDetails;

        private RequestLineItemStatus()
        {
        }

        public RequestLineItemStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static RequestLineItemStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new RequestLineItemStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
