using Application.Abstractions;

namespace Application.CQRS.SparePartGroup.Commands;

public class CreateSparePartGroupCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSparePartGroupCommandHandler : ICommandHandler<CreateSparePartGroupCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSparePartGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSparePartGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SparePartGroup.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.SparePartGroupRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SparePartGroupNotInserted);
    }
}