using Application.Abstractions;

namespace Application.CQRS.ContactType.Commands;

public class UpdateContactTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateContactTypeCommandHandler : ICommandHandler<UpdateContactTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateContactTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ContactTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ContactTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.UpdatedOn, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ContactTypeNotUpdated);
    }
}