using Application.Abstractions;

namespace Application.CQRS.Gender.Commands;

public class CreateGenderCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateGenderCommandHandler : ICommandHandler<CreateGenderCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGenderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Gender.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.GenderRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.GenderNotInserted);
    }
}