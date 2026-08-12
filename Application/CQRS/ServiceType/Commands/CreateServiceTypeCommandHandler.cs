using Application.Abstractions;

namespace Application.CQRS.ServiceType.Commands;

public class CreateServiceTypeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateServiceTypeCommandHandler : ICommandHandler<CreateServiceTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateServiceTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ServiceType.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ServiceTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ServiceTypeNotInserted);
    }
}