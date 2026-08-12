using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCountDetail : AggregateRootEntityBase<int>
    {
        public int? AssetCountFk { get; set; }
        public int? AssetFk { get; set; }
        public int? AssetCountStatusFk { get; set; }
        public string? Notes { get; set; }
        public AssetCount? AssetCountFkNavigation { get; set; }
        public AssetCountStatus? AssetCountStatusFkNavigation { get; set; }
        public Asset? AssetFkNavigation { get; set; }

        private List<AssetCountIssue> _assetCountIssues = new List<AssetCountIssue>();
        public IReadOnlyCollection<AssetCountIssue> AssetCountIssues => _assetCountIssues;

        public AssetCountDetail()
        {
        }

        public AssetCountDetail(int? assetCountFk, int? assetFk, int? assetCountStatusFk, string? notes, bool isActive) : this()
        {
            AssetCountFk = assetCountFk;
            AssetFk = assetFk;
            AssetCountStatusFk = assetCountStatusFk;
            Notes = notes;
            IsActive = isActive;
        }

        public static AssetCountDetail Create(int? assetCountFk, int? assetFk, int? assetCountStatusFk, string? notes, bool isActive)
        {

            return new AssetCountDetail(assetCountFk, assetFk, assetCountStatusFk, notes, isActive);
        }

        public void Update(int? assetCountFk, int? assetFk, int? assetCountStatusFk, string? notes, bool isActive)
        {
            AssetCountFk = assetCountFk;
            AssetFk = assetFk;
            AssetCountStatusFk = assetCountStatusFk;
            Notes = notes;
            IsActive = isActive;
        }
    }
}
