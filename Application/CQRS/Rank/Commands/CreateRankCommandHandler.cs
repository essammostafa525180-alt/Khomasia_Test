using Application.Abstractions;

namespace Application.CQRS.Rank.Commands;

public class CreateRankCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRankCommandHandler : ICommandHandler<CreateRankCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRankCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRankCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Rank.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.RankRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RankNotInserted);
    }
}