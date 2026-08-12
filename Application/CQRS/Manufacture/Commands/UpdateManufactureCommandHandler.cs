using Application.Abstractions;

namespace Application.CQRS.Manufacture.Commands;

public class UpdateManufactureCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateManufactureCommandHandler : ICommandHandler<UpdateManufactureCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateManufactureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ManufactureRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ManufactureNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ManufactureNotUpdated);
    }
}