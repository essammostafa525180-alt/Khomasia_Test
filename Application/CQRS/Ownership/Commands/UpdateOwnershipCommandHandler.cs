using Application.Abstractions;

namespace Application.CQRS.Ownership.Commands;

public class UpdateOwnershipCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateOwnershipCommandHandler : ICommandHandler<UpdateOwnershipCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOwnershipCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOwnershipCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OwnershipRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OwnershipNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OwnershipNotUpdated);
    }
}