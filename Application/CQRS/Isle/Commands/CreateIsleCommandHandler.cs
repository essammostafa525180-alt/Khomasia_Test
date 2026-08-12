using Application.Abstractions;

namespace Application.CQRS.Isle.Commands;

public class CreateIsleCommand : ICommand<Result<int>>
{
        public int StorageUnitFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Sequence { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateIsleCommandHandler : ICommandHandler<CreateIsleCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateIsleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateIsleCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Isle.Create(request.StorageUnitFk, request.Code, request.Name, request.Sequence, request.IsActive);

        await _unitOfWork.IsleRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.IsleNotInserted);
    }
}
