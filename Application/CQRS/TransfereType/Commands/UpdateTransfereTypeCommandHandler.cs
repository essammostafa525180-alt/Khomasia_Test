using Application.Abstractions;

namespace Application.CQRS.TransfereType.Commands;

public class UpdateTransfereTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateTransfereTypeCommandHandler : ICommandHandler<UpdateTransfereTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransfereTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTransfereTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransfereTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransfereTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransfereTypeNotUpdated);
    }
}