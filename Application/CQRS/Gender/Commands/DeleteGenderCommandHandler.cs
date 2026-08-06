using Application.Abstractions;

namespace Application.CQRS.Gender.Commands;

public class DeleteGenderCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteGenderCommandHandler : ICommandHandler<DeleteGenderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.GenderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.GenderNotFound);

        _unitOfWork.GenderRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.GenderNotDeleted);
    }
}