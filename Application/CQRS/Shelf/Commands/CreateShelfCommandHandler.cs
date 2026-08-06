using Application.Abstractions;

namespace Application.CQRS.Shelf.Commands;

public class CreateShelfCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? RackFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateShelfCommandHandler : ICommandHandler<CreateShelfCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateShelfCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Shelf.Create(request.Name, request.NameAr, request.RackFk, request.IsActive);

        await _unitOfWork.ShelfRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ShelfNotInserted);
    }
}