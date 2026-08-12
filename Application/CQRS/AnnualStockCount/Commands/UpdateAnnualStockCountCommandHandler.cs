using Application.Abstractions;

namespace Application.CQRS.AnnualStockCount.Commands;

public class UpdateAnnualStockCountCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? StoreFk { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAnnualStockCountCommandHandler : ICommandHandler<UpdateAnnualStockCountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnualStockCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAnnualStockCountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AnnualStockCountNotFound);

        entity.Update(request.YearId, request.StoreFk, request.IsCompleted, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AnnualStockCountNotUpdated);
    }
}