using Application.Abstractions;

namespace Application.CQRS.SubSection.Commands;

public class CreateSubSectionCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? SectionFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSubSectionCommandHandler : ICommandHandler<CreateSubSectionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSubSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SubSection.Create(request.Code, request.Name, request.NameAr, request.SectionFk, request.IsActive);

        await _unitOfWork.SubSectionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SubSectionNotInserted);
    }
}