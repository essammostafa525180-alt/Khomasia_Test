using Application.Abstractions;

namespace Application.CQRS.SecProperty.Commands;

public class CreateSecPropertyCommand : ICommand<Result<int>>
{
        public string? Type { get; set; }
        public string? Name { get; set; }
        public int? SecModuleId { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecPropertyCommandHandler : ICommandHandler<CreateSecPropertyCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecPropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecPropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SecProperty.Create(request.Type, request.Name, request.SecModuleId, request.NameAr, request.IsActive);

        await _unitOfWork.SecPropertyRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecPropertyNotInserted);
    }
}