using Application.Abstractions;

namespace Application.CQRS.Rack.Commands;

public class CreateRackCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? IsleFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRackCommandHandler : ICommandHandler<CreateRackCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRackCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRackCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Rack.Create(request.Name, request.NameAr, request.IsleFk, request.IsActive);

        await _unitOfWork.RackRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RackNotInserted);
    }
}