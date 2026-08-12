using Application.Abstractions;

namespace Application.CQRS.Shelf.Commands;

public class UpdateShelfCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int IsleFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public decimal? MaxWeight { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateShelfCommandHandler : ICommandHandler<UpdateShelfCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateShelfCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ShelfRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ShelfNotFound);

        entity.Update(request.IsleFk, request.Code, request.Name, request.Level, request.MaxWeight, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ShelfNotUpdated);
    }
}
