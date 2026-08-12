using Application.Abstractions;

namespace Application.CQRS.ReturnStatus.Commands;

public class CreateReturnStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateReturnStatusCommandHandler : ICommandHandler<CreateReturnStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReturnStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateReturnStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ReturnStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ReturnStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ReturnStatusNotInserted);
    }
}