using Application.Abstractions;

namespace Application.CQRS.Isle.Commands;

public class UpdateIsleCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int StorageUnitFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Sequence { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateIsleCommandHandler : ICommandHandler<UpdateIsleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateIsleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateIsleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.IsleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.IsleNotFound);

        entity.Update(request.StorageUnitFk, request.Code, request.Name, request.Sequence, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.IsleNotUpdated);
    }
}
