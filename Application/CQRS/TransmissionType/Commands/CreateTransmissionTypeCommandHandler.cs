using Application.Abstractions;

namespace Application.CQRS.TransmissionType.Commands;

public class CreateTransmissionTypeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateTransmissionTypeCommandHandler : ICommandHandler<CreateTransmissionTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransmissionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateTransmissionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.TransmissionType.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.TransmissionTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.TransmissionTypeNotInserted);
    }
}