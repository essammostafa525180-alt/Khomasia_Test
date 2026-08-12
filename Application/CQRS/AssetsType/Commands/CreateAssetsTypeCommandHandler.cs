using Application.Abstractions;

namespace Application.CQRS.AssetsType.Commands;

public class CreateAssetsTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetsTypeCommandHandler : ICommandHandler<CreateAssetsTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetsTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetsTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetsType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetsTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetsTypeNotInserted);
    }
}