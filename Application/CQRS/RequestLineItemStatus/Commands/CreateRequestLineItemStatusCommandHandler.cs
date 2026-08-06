using Application.Abstractions;

namespace Application.CQRS.RequestLineItemStatus.Commands;

public class CreateRequestLineItemStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRequestLineItemStatusCommandHandler : ICommandHandler<CreateRequestLineItemStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRequestLineItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRequestLineItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.RequestLineItemStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.RequestLineItemStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RequestLineItemStatusNotInserted);
    }
}