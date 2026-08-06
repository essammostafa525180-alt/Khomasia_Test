using Application.Abstractions;

namespace Application.CQRS.SparePartGroup.Commands;

public class UpdateSparePartGroupCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSparePartGroupCommandHandler : ICommandHandler<UpdateSparePartGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSparePartGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSparePartGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SparePartGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SparePartGroupNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SparePartGroupNotUpdated);
    }
}