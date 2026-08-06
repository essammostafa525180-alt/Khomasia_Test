using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssignCostCenterToSector : AggregateRootEntityBase<int>
    {
        public int? SectorFk { get; set; }
        public int? CostCenterFk { get; set; }
        public CostCenter? CostCenterFkNavigation { get; set; }
        public Sector? SectorFkNavigation { get; set; }

        public AssignCostCenterToSector()
        {
        }

        public AssignCostCenterToSector(int? sectorFk, int? costCenterFk, bool isActive) : this()
        {
            SectorFk = sectorFk;
            CostCenterFk = costCenterFk;
            IsActive = isActive;
        }

        public static AssignCostCenterToSector Create(int? sectorFk, int? costCenterFk, bool isActive)
        {

            return new AssignCostCenterToSector(sectorFk, costCenterFk, isActive);
        }

        public void Update(int? sectorFk, int? costCenterFk, bool isActive)
        {
            SectorFk = sectorFk;
            CostCenterFk = costCenterFk;
            IsActive = isActive;
        }
    }
}
