using Application.Abstractions;

namespace Application.CQRS.AssetStatus.Commands;

public class CreateAssetStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetStatusCommandHandler : ICommandHandler<CreateAssetStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetStatusNotInserted);
    }
}