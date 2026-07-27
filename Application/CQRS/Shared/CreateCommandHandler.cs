using Domain.Primitives;
using Mapster;

public class CreateCommand<T> : IRequest<Result<T>>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}

internal class CreateCommandHandler<TCommand, TEntity, TId, TDto>
    : IRequestHandler<TCommand, Result<TDto>>
    where TCommand : CreateCommand<TDto>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    private readonly IUnitOfWork<TEntity, TId> _unitOfWork;

    public CreateCommandHandler(IUnitOfWork<TEntity, TId> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        // Map request to the entity (Assumes an appropriate Create method exists)
        var entity = Activator.CreateInstance(typeof(TEntity), request.Name) as TEntity;
        if (entity == null)
        {
            return Result<TDto>.Failure("Entity creation failed.");
        }

        // Add the entity to the repository and save
        await _unitOfWork.Repository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Map to DTO
        var dto = entity.Adapt<TDto>();

        return result > 0
            ? Result<TDto>.Success(dto)
            : Result<TDto>.Failure("Entity could not be saved.");
    }
}
