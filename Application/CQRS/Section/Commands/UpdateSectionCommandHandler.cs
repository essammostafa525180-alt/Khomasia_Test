using Application.Abstractions;

namespace Application.CQRS.Section.Commands;

public class UpdateSectionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSectionCommandHandler : ICommandHandler<UpdateSectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SectionNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SectionNotUpdated);
    }
}