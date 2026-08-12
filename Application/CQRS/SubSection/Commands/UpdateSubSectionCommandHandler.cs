using Application.Abstractions;

namespace Application.CQRS.SubSection.Commands;

public class UpdateSubSectionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? SectionFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSubSectionCommandHandler : ICommandHandler<UpdateSubSectionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSubSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSubSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SubSectionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SubSectionNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.SectionFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SubSectionNotUpdated);
    }
}