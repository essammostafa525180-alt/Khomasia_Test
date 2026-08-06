using Application.Abstractions;

namespace Application.CQRS.Language.Commands;

public class DeleteLanguageCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteLanguageCommandHandler : ICommandHandler<DeleteLanguageCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LanguageRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.LanguageNotFound);

        _unitOfWork.LanguageRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.LanguageNotDeleted);
    }
}