using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Employee.Queries;

public class GetEmployeeByIdQuery : IQuery<Result<EmployeeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, Result<EmployeeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<EmployeeDetailsResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<EmployeeDetailsResponse>.Failure(Errors.EmployeeNotFound);

        var response = entity.Adapt<EmployeeDetailsResponse>();

        return Result<EmployeeDetailsResponse>.Success(response);
    }
}