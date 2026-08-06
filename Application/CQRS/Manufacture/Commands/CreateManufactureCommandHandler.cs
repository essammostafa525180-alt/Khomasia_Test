using Application.Abstractions;

namespace Application.CQRS.Manufacture.Commands;

public class CreateManufactureCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateManufactureCommandHandler : ICommandHandler<CreateManufactureCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateManufactureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateManufactureCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Manufacture.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ManufactureRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ManufactureNotInserted);
    }
}