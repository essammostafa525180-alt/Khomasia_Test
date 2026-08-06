using Application.Abstractions;

namespace Application.CQRS.ReturnReason.Commands;

public class UpdateReturnReasonCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? IntegrationId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateReturnReasonCommandHandler : ICommandHandler<UpdateReturnReasonCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReturnReasonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateReturnReasonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ReturnReasonRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ReturnReasonNotFound);

        entity.Update(request.Name, request.NameAr, request.IntegrationId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ReturnReasonNotUpdated);
    }
}