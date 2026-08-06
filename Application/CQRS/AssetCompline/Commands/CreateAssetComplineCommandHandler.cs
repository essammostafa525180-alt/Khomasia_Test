using Application.Abstractions;

namespace Application.CQRS.AssetCompline.Commands;

public class CreateAssetComplineCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetComplineCommandHandler : ICommandHandler<CreateAssetComplineCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetComplineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetComplineCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCompline.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetComplineRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetComplineNotInserted);
    }
}