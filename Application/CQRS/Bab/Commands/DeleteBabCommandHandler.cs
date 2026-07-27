using Application.Abstractions;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.Bab.Commands;

public class DeleteBabCommand : ICommand<Result<int>>
{
    public int Id { get; set; }
};

internal class DeleteBabCommandHandler : ICommandHandler<DeleteBabCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;
    public DeleteBabCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
    {
        _unitOfWork = unitOfWork;
        _sharedLocalizer = sharedLocalizer;
    }

    public async Task<Result<int>> Handle(DeleteBabCommand request, CancellationToken cancellationToken)
    {
        var bab = await _unitOfWork.BabRepository.GetByIdAsync(request.Id);

        if (bab == default || bab.IsDeleted)
            return Result<int>.Failure(
             _sharedLocalizer[string.Format(_sharedLocalizer["{0} NotFound"],
             _sharedLocalizer[Errors.Bab])]);

        _unitOfWork.BabRepository.SoftDelete(bab);

        bab.DeletedAt = DateTime.Now;

        int isDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return isDeleted > 0
                ? Result<int>.Success(request.Id)
                : Result<int>.Failure(Errors.BabNotDeleted);
    }
};






