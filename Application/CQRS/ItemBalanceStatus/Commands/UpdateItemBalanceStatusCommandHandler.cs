using Application.Abstractions;

namespace Application.CQRS.ItemBalanceStatus.Commands;

public class UpdateItemBalanceStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateItemBalanceStatusCommandHandler : ICommandHandler<UpdateItemBalanceStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemBalanceStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateItemBalanceStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemBalanceStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemBalanceStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemBalanceStatusNotUpdated);
    }
}