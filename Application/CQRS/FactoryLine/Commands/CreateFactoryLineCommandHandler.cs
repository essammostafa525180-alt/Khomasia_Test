using Application.Abstractions;

namespace Application.CQRS.FactoryLine.Commands;

public class CreateFactoryLineCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int FactoryFk { get; set; }
        public string Name { get; set; }
        public string? NameAr { get; set; }
        public int? Capacity { get; set; }
        public string LineTypes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateFactoryLineCommandHandler : ICommandHandler<CreateFactoryLineCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFactoryLineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateFactoryLineCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.CompanyAggregate.FactoryLine.Create(request.Code, request.Description, request.FactoryFk, request.Name, request.NameAr, request.Capacity, request.LineTypes, request.IsActive);

        await _unitOfWork.FactoryLineRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.FactoryLineNotInserted);
    }
}