using Application.Abstractions;

namespace Application.CQRS.Rank.Commands;

public class UpdateRankCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRankCommandHandler : ICommandHandler<UpdateRankCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRankCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRankCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RankRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RankNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RankNotUpdated);
    }
}