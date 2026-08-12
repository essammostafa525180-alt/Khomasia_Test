using Application.Abstractions;

namespace Application.CQRS.Ou.Commands;

public class UpdateOuCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateOuCommandHandler : ICommandHandler<UpdateOuCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOuCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOuCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OuRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OuNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OuNotUpdated);
    }
}