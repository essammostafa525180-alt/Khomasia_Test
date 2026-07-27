using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Hadiths.Queries
{
    public class GetHadithByIdQuery
  : IQuery<Result<HadithListResponse>>
    {

        public int Id { get; set; }
    }
    public class GetHadithByIdQueryHandler :
        IQueryHandler<GetHadithByIdQuery,
            Result<HadithListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHadithByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<HadithListResponse>> Handle(
            GetHadithByIdQuery request,
            CancellationToken cancellationToken)
        {
            var hadith = await _unitOfWork.HadithRepository.GetByIdAsync(request.Id);
            if (hadith is null)
                return Result<HadithListResponse>.Failure(Errors.HadithNotFound);

            var response = hadith.Adapt<HadithListResponse>();

            return Result<HadithListResponse>.Success(response);
        }
    }
}

