using Application.Abstractions;

namespace Application.CQRS.RequestLineItemStatus.Commands;

public class UpdateRequestLineItemStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRequestLineItemStatusCommandHandler : ICommandHandler<UpdateRequestLineItemStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRequestLineItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRequestLineItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RequestLineItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RequestLineItemStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RequestLineItemStatusNotUpdated);
    }
}