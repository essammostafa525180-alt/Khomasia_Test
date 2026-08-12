using Domain.Aggregates.UserAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.SalesAggregate
{
    public class Visit : AggregateRootEntityBase<int>
    {
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Image { get; set; }
        public string? OtherSupplier { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public Customer? Customer { get; set; }
        public User? User { get; set; }

        public Visit()
        {
        }

        public Visit(int? customerId, int? userId, decimal? latitude, decimal? longitude, string? image, string? otherSupplier, DateTime? updatedOn, int? updatedBy, bool isActive) : this()
        {
            CustomerId = customerId;
            UserId = userId;
            Latitude = latitude;
            Longitude = longitude;
            Image = image;
            OtherSupplier = otherSupplier;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
            IsActive = isActive;
        }

        public static Visit Create(int? customerId, int? userId, decimal? latitude, decimal? longitude, string? image, string? otherSupplier, DateTime? updatedOn, int? updatedBy, bool isActive)
        {

            return new Visit(customerId, userId, latitude, longitude, image, otherSupplier, updatedOn, updatedBy, isActive);
        }

        public void Update(int? customerId, int? userId, decimal? latitude, decimal? longitude, string? image, string? otherSupplier, DateTime? updatedOn, int? updatedBy, bool isActive)
        {
            CustomerId = customerId;
            UserId = userId;
            Latitude = latitude;
            Longitude = longitude;
            Image = image;
            OtherSupplier = otherSupplier;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
            IsActive = isActive;
        }
    }
}
