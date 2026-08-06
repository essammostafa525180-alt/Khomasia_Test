using Application.Abstractions;

namespace Application.CQRS.Rack.Commands;

public class UpdateRackCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? IsleFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRackCommandHandler : ICommandHandler<UpdateRackCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRackCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRackCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RackRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RackNotFound);

        entity.Update(request.Name, request.NameAr, request.IsleFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RackNotUpdated);
    }
}