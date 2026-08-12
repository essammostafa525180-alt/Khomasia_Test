using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Line : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? ProjectFk { get; private set; }
        public Project? ProjectFkNavigation { get; private set; }

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private Line()
        {
        }

        public Line(string? name, string? nameAr, int? projectFk, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            ProjectFk = projectFk;
            IsActive = isActive;
        }

        public static Line Create(string? name, string? nameAr, int? projectFk, bool isActive)
        {

            return new Line(name, nameAr, projectFk, isActive);
        }

        public void Update(string? name, string? nameAr, int? projectFk, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            ProjectFk = projectFk;
            IsActive = isActive;
        }
    }
}
