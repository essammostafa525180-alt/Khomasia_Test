using Application.Abstractions;

namespace Application.CQRS.Language.Commands;

public class CreateLanguageCommand : ICommand<Result<int>>
{
        public string? LanguageName { get; set; }
        public string? LanguageNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateLanguageCommandHandler : ICommandHandler<CreateLanguageCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Language.Create(request.LanguageName, request.LanguageNameAr, request.IsActive);

        await _unitOfWork.LanguageRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.LanguageNotInserted);
    }
}