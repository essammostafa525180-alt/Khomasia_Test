using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCountIssue : AggregateRootEntityBase<int>
    {
        public string? IssueNumber { get; set; }
        public int? AssetCountDetailFk { get; set; }
        public int? AssetCountIssueStatusFk { get; set; }
        public string? Notes { get; set; }
        public AssetCountDetail? AssetCountDetailFkNavigation { get; set; }
        public AssetCountIssueStatus? AssetCountIssueStatusFkNavigation { get; set; }

        public AssetCountIssue()
        {
        }

        public AssetCountIssue(string? issueNumber, int? assetCountDetailFk, int? assetCountIssueStatusFk, string? notes, bool isActive) : this()
        {
            IssueNumber = issueNumber;
            AssetCountDetailFk = assetCountDetailFk;
            AssetCountIssueStatusFk = assetCountIssueStatusFk;
            Notes = notes;
            IsActive = isActive;
        }

        public static AssetCountIssue Create(string? issueNumber, int? assetCountDetailFk, int? assetCountIssueStatusFk, string? notes, bool isActive)
        {

            return new AssetCountIssue(issueNumber, assetCountDetailFk, assetCountIssueStatusFk, notes, isActive);
        }

        public void Update(string? issueNumber, int? assetCountDetailFk, int? assetCountIssueStatusFk, string? notes, bool isActive)
        {
            IssueNumber = issueNumber;
            AssetCountDetailFk = assetCountDetailFk;
            AssetCountIssueStatusFk = assetCountIssueStatusFk;
            Notes = notes;
            IsActive = isActive;
        }
    }
}
