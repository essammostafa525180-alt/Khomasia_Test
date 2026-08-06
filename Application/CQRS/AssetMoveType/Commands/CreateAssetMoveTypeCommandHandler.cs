using Application.Abstractions;

namespace Application.CQRS.AssetMoveType.Commands;

public class CreateAssetMoveTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetMoveTypeCommandHandler : ICommandHandler<CreateAssetMoveTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetMoveTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetMoveTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetMoveType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetMoveTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetMoveTypeNotInserted);
    }
}