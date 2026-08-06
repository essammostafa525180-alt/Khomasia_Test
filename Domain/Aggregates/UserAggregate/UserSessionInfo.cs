using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.UserAggregate
{
    public class UserSessionInfo : AggregateRootEntityBase<int>
    {
        public int UserId { get; set; }
        public DateTime LastHit { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool? RemeberMe { get; set; }
        public string? Language { get; set; }
        public string? ValidModules { get; set; }
        public Guid UserToken { get; set; }
        public User? User { get; set; }

        private List<UserSessionInfoDetail> _userSessionInfoDetails = new List<UserSessionInfoDetail>();
        public IReadOnlyCollection<UserSessionInfoDetail> UserSessionInfoDetails => _userSessionInfoDetails;

        public UserSessionInfo()
        {
        }

        public UserSessionInfo(int userId, DateTime lastHit, DateTime expireAt, bool? remeberMe, string? language, string? validModules, Guid userToken, bool isActive) : this()
        {
            UserId = userId;
            LastHit = lastHit;
            ExpireAt = expireAt;
            RemeberMe = remeberMe;
            Language = language;
            ValidModules = validModules;
            UserToken = userToken;
            IsActive = isActive;
        }

        public static UserSessionInfo Create(int userId, DateTime lastHit, DateTime expireAt, bool? remeberMe, string? language, string? validModules, Guid userToken, bool isActive)
        {

            return new UserSessionInfo(userId, lastHit, expireAt, remeberMe, language, validModules, userToken, isActive);
        }

        public void Update(int userId, DateTime lastHit, DateTime expireAt, bool? remeberMe, string? language, string? validModules, Guid userToken, bool isActive)
        {
            UserId = userId;
            LastHit = lastHit;
            ExpireAt = expireAt;
            RemeberMe = remeberMe;
            Language = language;
            ValidModules = validModules;
            UserToken = userToken;
            IsActive = isActive;
        }
    }
}
