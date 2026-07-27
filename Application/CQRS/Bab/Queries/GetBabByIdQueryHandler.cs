using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Bab.Queries
{

    public class GetBabByIdQuery
  : IQuery<Result<BabDetailsResponse>>
    {
        public int Id { get; set; }
    }
    public class GetBabByIdQueryHandler
         : IQueryHandler<GetBabByIdQuery, Result<BabDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBabByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<BabDetailsResponse>> Handle(
            GetBabByIdQuery request,
            CancellationToken cancellationToken)
        {
            var bab = await _unitOfWork.BabRepository
                .GetByIdAsync(request.Id);

            if (bab is null)
                return Result<BabDetailsResponse>.Failure(Errors.BabNotFound);

            var response = bab.Adapt<BabDetailsResponse>();

            return Result<BabDetailsResponse>.Success(response);
        }
    }
}




