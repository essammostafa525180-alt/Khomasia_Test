using Application.Abstractions;

namespace Application.CQRS.HadithSharhMissing.Commands;

public class CreateHadithSharhMissingCommand : ICommand<Result<int>>
{
        public int HadithNumber { get; set; }
        public int? BabId { get; set; }
        public int? BookSharhId { get; set; }
        public string? SharhWithSign { get; set; }
        public string? SharhWithNoSign { get; set; }
        public int HadithId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateHadithSharhMissingCommandHandler : ICommandHandler<CreateHadithSharhMissingCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateHadithSharhMissingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateHadithSharhMissingCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Aggregates.BookSharhAggregate.HadithSharhMissing
        {
            HadithNumber = request.HadithNumber,
            BabId = request.BabId,
            BookSharhId = request.BookSharhId,
            SharhWithSign = request.SharhWithSign,
            SharhWithNoSign = request.SharhWithNoSign,
            HadithId = request.HadithId,
            IsActive = request.IsActive
        };

        await _unitOfWork.HadithSharhMissingRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.HadithSharhMissingNotInserted);
    }
}