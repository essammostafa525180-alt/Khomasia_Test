using Application.Abstractions;

namespace Application.CQRS.AssetFunctionality.Commands;

public class CreateAssetFunctionalityCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetFunctionalityCommandHandler : ICommandHandler<CreateAssetFunctionalityCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetFunctionalityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetFunctionalityCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetFunctionality.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetFunctionalityRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetFunctionalityNotInserted);
    }
}