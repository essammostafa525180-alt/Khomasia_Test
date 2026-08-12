using Application.Abstractions;

namespace Application.CQRS.PoserviceType.Commands;

public class CreatePoserviceTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePoserviceTypeCommandHandler : ICommandHandler<CreatePoserviceTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePoserviceTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePoserviceTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.PoserviceType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.PoserviceTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PoserviceTypeNotInserted);
    }
}