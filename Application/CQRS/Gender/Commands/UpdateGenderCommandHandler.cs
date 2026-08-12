using Application.Abstractions;

namespace Application.CQRS.Gender.Commands;

public class UpdateGenderCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateGenderCommandHandler : ICommandHandler<UpdateGenderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGenderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.GenderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.GenderNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.GenderNotUpdated);
    }
}