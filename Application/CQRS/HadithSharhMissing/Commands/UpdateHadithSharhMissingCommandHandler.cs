using Application.Abstractions;

namespace Application.CQRS.HadithSharhMissing.Commands;

public class UpdateHadithSharhMissingCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int HadithNumber { get; set; }
        public int? BabId { get; set; }
        public int? BookSharhId { get; set; }
        public string? SharhWithSign { get; set; }
        public string? SharhWithNoSign { get; set; }
        public int HadithId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateHadithSharhMissingCommandHandler : ICommandHandler<UpdateHadithSharhMissingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHadithSharhMissingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateHadithSharhMissingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.HadithSharhMissingRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.HadithSharhMissingNotFound);

        entity.HadithNumber = request.HadithNumber;
        entity.BabId = request.BabId;
        entity.BookSharhId = request.BookSharhId;
        entity.SharhWithSign = request.SharhWithSign;
        entity.SharhWithNoSign = request.SharhWithNoSign;
        entity.HadithId = request.HadithId;
        entity.IsActive = request.IsActive;

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.HadithSharhMissingNotUpdated);
    }
}