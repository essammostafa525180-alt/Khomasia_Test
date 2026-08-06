using Application.Abstractions;

namespace Application.CQRS.Pdadetail.Commands;

public class DeletePdadetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePdadetailCommandHandler : ICommandHandler<DeletePdadetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePdadetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePdadetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdadetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdadetailNotFound);

        _unitOfWork.PdadetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdadetailNotDeleted);
    }
}