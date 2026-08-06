using Application.Abstractions;

namespace Application.CQRS.ItemRequestStatus.Commands;

public class CreateItemRequestStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateItemRequestStatusCommandHandler : ICommandHandler<CreateItemRequestStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemRequestStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateItemRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ItemRequestStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ItemRequestStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ItemRequestStatusNotInserted);
    }
}