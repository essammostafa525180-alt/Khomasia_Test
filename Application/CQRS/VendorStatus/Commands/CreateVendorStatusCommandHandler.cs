using Application.Abstractions;

namespace Application.CQRS.VendorStatus.Commands;

public class CreateVendorStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorStatusCommandHandler : ICommandHandler<CreateVendorStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VendorStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorStatusNotInserted);
    }
}