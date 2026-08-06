using Application.Abstractions;

namespace Application.CQRS.ItemRequestStatus.Commands;

public class UpdateItemRequestStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateItemRequestStatusCommandHandler : ICommandHandler<UpdateItemRequestStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemRequestStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateItemRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemRequestStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemRequestStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemRequestStatusNotUpdated);
    }
}