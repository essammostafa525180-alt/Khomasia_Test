using Application.Abstractions;

namespace Application.CQRS.Contact.Commands;

public class UpdateContactCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? ContactValue { get; set; }
        public int? ContactTypeId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ContactRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ContactNotFound);

        entity.Update(request.ContactValue, request.ContactTypeId, request.UpdatedOn, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ContactNotUpdated);
    }
}