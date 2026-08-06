using Application.Abstractions;

namespace Application.CQRS.VendorOrderScreen.Commands;

public class CreateVendorOrderScreenCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderScreenCommandHandler : ICommandHandler<CreateVendorOrderScreenCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderScreenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderScreenCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorOrderScreen.Create(request.Code, request.Name, request.IsActive);

        await _unitOfWork.VendorOrderScreenRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderScreenNotInserted);
    }
}