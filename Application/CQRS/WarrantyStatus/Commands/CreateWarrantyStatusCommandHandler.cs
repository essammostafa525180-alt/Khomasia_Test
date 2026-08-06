using Application.Abstractions;

namespace Application.CQRS.WarrantyStatus.Commands;

public class CreateWarrantyStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateWarrantyStatusCommandHandler : ICommandHandler<CreateWarrantyStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateWarrantyStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateWarrantyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.WarrantyStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.WarrantyStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.WarrantyStatusNotInserted);
    }
}