using Application.Abstractions;

namespace Application.CQRS.TransfereType.Commands;

public class CreateTransfereTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateTransfereTypeCommandHandler : ICommandHandler<CreateTransfereTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransfereTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateTransfereTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.TransfereType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.TransfereTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.TransfereTypeNotInserted);
    }
}