using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetCountIssueStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetCountIssue> _assetCountIssues = new List<AssetCountIssue>();
        public IReadOnlyCollection<AssetCountIssue> AssetCountIssues => _assetCountIssues;

        private AssetCountIssueStatus()
        {
        }

        public AssetCountIssueStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetCountIssueStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetCountIssueStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
