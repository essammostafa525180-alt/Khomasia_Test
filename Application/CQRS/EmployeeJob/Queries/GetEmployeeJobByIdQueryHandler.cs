using Application.Abstractions;
using Mapster;

namespace Application.CQRS.EmployeeJob.Queries;

public class GetEmployeeJobByIdQuery : IQuery<Result<EmployeeJobDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetEmployeeJobByIdQueryHandler : IQueryHandler<GetEmployeeJobByIdQuery, Result<EmployeeJobDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeJobByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<EmployeeJobDetailsResponse>> Handle(GetEmployeeJobByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EmployeeJobRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<EmployeeJobDetailsResponse>.Failure(Errors.EmployeeJobNotFound);

        var response = entity.Adapt<EmployeeJobDetailsResponse>();

        return Result<EmployeeJobDetailsResponse>.Success(response);
    }
}