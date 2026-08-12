using Application.Abstractions;

namespace Application.CQRS.State.Commands;

public class UpdateStateCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CountryFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStateCommandHandler : ICommandHandler<UpdateStateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StateNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.CountryFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StateNotUpdated);
    }
}