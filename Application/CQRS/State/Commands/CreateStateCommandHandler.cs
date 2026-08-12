using Application.Abstractions;

namespace Application.CQRS.State.Commands;

public class CreateStateCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CountryFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateStateCommandHandler : ICommandHandler<CreateStateCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.State.Create(request.Code, request.Name, request.NameAr, request.CountryFk, request.IsActive);

        await _unitOfWork.StateRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StateNotInserted);
    }
}