using Application.Abstractions;

namespace Application.CQRS.Customer.Commands;

public class UpdateCustomerCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CustomerNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.Phone, request.Address, request.ContactPerson, request.CommercialRecord, request.OtherVendor, request.CompanyFk, request.SectorFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CustomerNotUpdated);
    }
}