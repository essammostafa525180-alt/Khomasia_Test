using Application.Abstractions;

namespace Application.CQRS.Pdaassignment.Commands;

public class UpdatePdaassignmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? PdadetailFk { get; set; }
        public int? UserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePdaassignmentCommandHandler : ICommandHandler<UpdatePdaassignmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePdaassignmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePdaassignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdaassignmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdaassignmentNotFound);

        entity.Update(request.PdadetailFk, request.UserFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdaassignmentNotUpdated);
    }
}