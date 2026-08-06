using Application.Abstractions;

namespace Application.CQRS.ItemBalanceStatus.Commands;

public class CreateItemBalanceStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateItemBalanceStatusCommandHandler : ICommandHandler<CreateItemBalanceStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemBalanceStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateItemBalanceStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ItemBalanceStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ItemBalanceStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ItemBalanceStatusNotInserted);
    }
}