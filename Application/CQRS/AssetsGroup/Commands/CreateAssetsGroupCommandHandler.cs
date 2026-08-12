using Application.Abstractions;

namespace Application.CQRS.AssetsGroup.Commands;

public class CreateAssetsGroupCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public decimal? DepreciationDuration { get; set; }
        public decimal? DepreciationRate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetsGroupCommandHandler : ICommandHandler<CreateAssetsGroupCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetsGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetsGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetsGroup.Create(request.Name, request.NameAr, request.DepreciationDuration, request.DepreciationRate, request.IsActive);

        await _unitOfWork.AssetsGroupRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetsGroupNotInserted);
    }
}