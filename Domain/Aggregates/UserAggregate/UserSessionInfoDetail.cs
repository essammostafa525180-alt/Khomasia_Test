using Domain.Primitives;

namespace Domain.Aggregates.UserAggregate
{
    public class UserSessionInfoDetail : AggregateRootEntityBase<int>
    {
        public int? UserSessionInfoId { get; set; }
        public int? InfoKey { get; set; }
        public string? InfoValue { get; set; }
        public string? InfoDescription { get; set; }
        public UserSessionInfo? UserSessionInfo { get; set; }

        public UserSessionInfoDetail()
        {
        }

        public UserSessionInfoDetail(int? userSessionInfoId, int? infoKey, string? infoValue, string? infoDescription, bool isActive) : this()
        {
            UserSessionInfoId = userSessionInfoId;
            InfoKey = infoKey;
            InfoValue = infoValue;
            InfoDescription = infoDescription;
            IsActive = isActive;
        }

        public static UserSessionInfoDetail Create(int? userSessionInfoId, int? infoKey, string? infoValue, string? infoDescription, bool isActive)
        {

            return new UserSessionInfoDetail(userSessionInfoId, infoKey, infoValue, infoDescription, isActive);
        }

        public void Update(int? userSessionInfoId, int? infoKey, string? infoValue, string? infoDescription, bool isActive)
        {
            UserSessionInfoId = userSessionInfoId;
            InfoKey = infoKey;
            InfoValue = infoValue;
            InfoDescription = infoDescription;
            IsActive = isActive;
        }
    }
}
