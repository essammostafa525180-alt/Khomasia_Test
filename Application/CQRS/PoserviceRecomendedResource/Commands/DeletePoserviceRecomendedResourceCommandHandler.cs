using Application.Abstractions;

namespace Application.CQRS.PoserviceRecomendedResource.Commands;

public class DeletePoserviceRecomendedResourceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePoserviceRecomendedResourceCommandHandler : ICommandHandler<DeletePoserviceRecomendedResourceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePoserviceRecomendedResourceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePoserviceRecomendedResourceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceRecomendedResourceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceRecomendedResourceNotFound);

        _unitOfWork.PoserviceRecomendedResourceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceRecomendedResourceNotDeleted);
    }
}