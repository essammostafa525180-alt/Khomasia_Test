using Application.Abstractions;

namespace Application.CQRS.User.Commands;

public class CreateUserCommand : ICommand<Result<int>>
{
        public DateTime? UpdatedOn { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Contact { get; set; }
        public bool? Active { get; set; }
        public int? Ouid { get; set; }
        public string? NameAr { get; set; }
        public int? BranchId { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? ForcePasswordChange { get; set; }
        public int? EmployeeId { get; set; }
        public int? MaxDiscount { get; set; }
        public DateTime? PasswordCreationDate { get; set; }
        public string? FullName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public int? AdUserId { get; set; }
        public bool? IsPda { get; set; }
        public int? SingleSession { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.UserAggregate.User.Create(request.UpdatedOn, request.Code, request.Name, request.UserId, request.Password, request.Email, request.Phone, request.Address, request.Contact, request.Active, request.Ouid, request.NameAr, request.BranchId, request.LastLogin, request.ForcePasswordChange, request.EmployeeId, request.MaxDiscount, request.PasswordCreationDate, request.FullName, request.ProfilePicture, request.AdUserId, request.IsPda, request.SingleSession, request.Timestamp, request.IsActive);

        await _unitOfWork.UserRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.UserNotInserted);
    }
}