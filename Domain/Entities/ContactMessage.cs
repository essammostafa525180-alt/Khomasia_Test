using Domain.Primitives;

namespace Domain.Entities
{
    public class ContactMessage : AuditableEntityBase<int>
    {
        //public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string? Subject { get; private set; }
        public string Message { get; private set; } = null!;
        public string? PageUrl { get; private set; }
        public bool IsRead { get; private set; }
        public bool IsNote { get; private set; }

        private ContactMessage() { } // EF

        public static ContactMessage Create(string name, string email, string message, string? subject, string pageUrl = null, bool isNote = false)
        {
            return new ContactMessage
            {
                Name = name,
                Email = email,
                Message = message,
                Subject = subject,
                IsNote = isNote,
                PageUrl = pageUrl,
                CreatedOn = DateTime.UtcNow
            };
        }

        public void MarkAsRead() => IsRead = true;
    }
}