using Application.Abstractions;

namespace Application.CQRS.Language.Commands;

public class UpdateLanguageCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateLanguageCommandHandler : ICommandHandler<UpdateLanguageCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LanguageRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.LanguageNotFound);

        entity.Update(request.LanguageName, request.LanguageNameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.LanguageNotUpdated);
    }
}