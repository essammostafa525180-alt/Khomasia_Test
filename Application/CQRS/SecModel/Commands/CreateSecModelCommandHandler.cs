using Application.Abstractions;

namespace Application.CQRS.SecModel.Commands;

public class CreateSecModelCommand : ICommand<Result<int>>
{
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public string? ModelDisplayName { get; set; }
        public int? SecModuleId { get; set; }
        public string? ModelDisplayNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecModelCommandHandler : ICommandHandler<CreateSecModelCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecModelCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecModel.Create(request.ModelId, request.ModelName, request.ModelDisplayName, request.SecModuleId, request.ModelDisplayNameAr, request.IsActive);

        await _unitOfWork.SecModelRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecModelNotInserted);
    }
}