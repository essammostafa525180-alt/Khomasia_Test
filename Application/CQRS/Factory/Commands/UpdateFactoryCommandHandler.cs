using Application.Abstractions;

namespace Application.CQRS.Factory.Commands;

public class UpdateFactoryCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateFactoryCommandHandler : ICommandHandler<UpdateFactoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFactoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateFactoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.FactoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.FactoryNotFound);

        entity.Update(request.Code, request.Description, request.Address, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.FactoryNotUpdated);
    }
}