using Application.Abstractions;

namespace Application.CQRS.Customer.Commands;

public class CreateCustomerCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public string? CommercialRecord { get; set; }
        public string? OtherVendor { get; set; }
        public int? CompanyFk { get; set; }
        public int? SectorFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.Customer.Create(request.Code, request.Name, request.NameAr, request.Phone, request.Address, request.ContactPerson, request.CommercialRecord, request.OtherVendor, request.CompanyFk, request.SectorFk, request.IsActive);

        await _unitOfWork.CustomerRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.CustomerNotInserted);
    }
}