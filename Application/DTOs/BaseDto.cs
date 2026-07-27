
namespace Application.DTOs;

public abstract class BaseDto<T>
{
    public T Id { get; set; } = default!;
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
