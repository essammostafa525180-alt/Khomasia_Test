using Application.Abstractions;

namespace Application.CQRS.VendorType.Commands;

public class CreateVendorTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorTypeCommandHandler : ICommandHandler<CreateVendorTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VendorTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorTypeNotInserted);
    }
}