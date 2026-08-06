using Application.Abstractions;

namespace Application.CQRS.AssetScrapStatus.Commands;

public class CreateAssetScrapStatusCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetScrapStatusCommandHandler : ICommandHandler<CreateAssetScrapStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetScrapStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetScrapStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetScrapStatus.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetScrapStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetScrapStatusNotInserted);
    }
}