using Application.Abstractions;

namespace Application.CQRS.PossessionType.Commands;

public class CreatePossessionTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePossessionTypeCommandHandler : ICommandHandler<CreatePossessionTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePossessionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePossessionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.PossessionType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.PossessionTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PossessionTypeNotInserted);
    }
}