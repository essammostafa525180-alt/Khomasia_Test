using Application.Abstractions;

namespace Application.CQRS.UserSessionInfoDetail.Commands;

public class UpdateUserSessionInfoDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? UserSessionInfoId { get; set; }
        public int? InfoKey { get; set; }
        public string? InfoValue { get; set; }
        public string? InfoDescription { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateUserSessionInfoDetailCommandHandler : ICommandHandler<UpdateUserSessionInfoDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserSessionInfoDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserSessionInfoDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UserSessionInfoDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.UserSessionInfoDetailNotFound);

        entity.Update(request.UserSessionInfoId, request.InfoKey, request.InfoValue, request.InfoDescription, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.UserSessionInfoDetailNotUpdated);
    }
}