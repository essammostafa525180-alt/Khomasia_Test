using Application.Abstractions;

namespace Application.CQRS.Factory.Commands;

public class CreateFactoryCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateFactoryCommandHandler : ICommandHandler<CreateFactoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFactoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.CompanyAggregate.Factory.Create(request.Code, request.Description, request.Address, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.FactoryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.FactoryNotInserted);
    }
}