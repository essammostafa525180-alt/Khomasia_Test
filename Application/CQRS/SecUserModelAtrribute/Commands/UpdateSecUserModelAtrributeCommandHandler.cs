using Application.Abstractions;

namespace Application.CQRS.SecUserModelAtrribute.Commands;

public class UpdateSecUserModelAtrributeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModelAttributeId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecUserModelAtrributeCommandHandler : ICommandHandler<UpdateSecUserModelAtrributeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecUserModelAtrributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecUserModelAtrributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserModelAtrributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserModelAtrributeNotFound);

        entity.Update(request.UserId, request.ModelAttributeId, request.Mode, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserModelAtrributeNotUpdated);
    }
}