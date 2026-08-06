using Application.Abstractions;

namespace Application.CQRS.Pdaassignment.Commands;

public class CreatePdaassignmentCommand : ICommand<Result<int>>
{
        public int? PdadetailFk { get; set; }
        public int? UserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePdaassignmentCommandHandler : ICommandHandler<CreatePdaassignmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePdaassignmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePdaassignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.PdaAggregate.Pdaassignment.Create(request.PdadetailFk, request.UserFk, request.IsActive);

        await _unitOfWork.PdaassignmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PdaassignmentNotInserted);
    }
}