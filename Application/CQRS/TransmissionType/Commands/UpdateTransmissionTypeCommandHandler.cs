using Application.Abstractions;

namespace Application.CQRS.TransmissionType.Commands;

public class UpdateTransmissionTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateTransmissionTypeCommandHandler : ICommandHandler<UpdateTransmissionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransmissionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTransmissionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransmissionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TransmissionTypeNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TransmissionTypeNotUpdated);
    }
}