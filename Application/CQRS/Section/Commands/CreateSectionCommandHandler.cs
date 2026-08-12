using Application.Abstractions;

namespace Application.CQRS.Section.Commands;

public class CreateSectionCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSectionCommandHandler : ICommandHandler<CreateSectionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Section.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.SectionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SectionNotInserted);
    }
}