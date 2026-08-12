using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.UserAggregate
{
    public class AdUser : AggregateRootEntityBase<int>
    {
        public string? AdAccount { get; set; }
        public string? Mail { get; set; }

        private List<User> _users = new List<User>();
        public IReadOnlyCollection<User> Users => _users;

        public AdUser()
        {
        }

        public AdUser(string? adAccount, string? mail, bool isActive) : this()
        {
            AdAccount = adAccount;
            Mail = mail;
            IsActive = isActive;
        }

        public static AdUser Create(string? adAccount, string? mail, bool isActive)
        {

            return new AdUser(adAccount, mail, isActive);
        }

        public void Update(string? adAccount, string? mail, bool isActive)
        {
            AdAccount = adAccount;
            Mail = mail;
            IsActive = isActive;
        }
    }
}
