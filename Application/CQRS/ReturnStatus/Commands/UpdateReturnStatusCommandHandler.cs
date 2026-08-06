using Application.Abstractions;

namespace Application.CQRS.ReturnStatus.Commands;

public class UpdateReturnStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateReturnStatusCommandHandler : ICommandHandler<UpdateReturnStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReturnStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateReturnStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ReturnStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ReturnStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ReturnStatusNotUpdated);
    }
}