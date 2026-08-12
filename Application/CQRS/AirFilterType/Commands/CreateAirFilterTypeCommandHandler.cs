using Application.Abstractions;

namespace Application.CQRS.AirFilterType.Commands;

public class CreateAirFilterTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAirFilterTypeCommandHandler : ICommandHandler<CreateAirFilterTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAirFilterTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAirFilterTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AirFilterType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AirFilterTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AirFilterTypeNotInserted);
    }
}