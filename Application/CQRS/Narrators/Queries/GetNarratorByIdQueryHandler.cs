using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.Narrators.Queries
{
    public class GetNarratorByIdQuery : IQuery<Result<NarratorDetailsResponse>>
    {
        public int Id { get; set; }
    }
    public class GetNarratorByIdQueryHandler :
        IQueryHandler<GetNarratorByIdQuery,
            Result<NarratorDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;
        public GetNarratorByIdQueryHandler(IUnitOfWork unitOfWork, IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NarratorDetailsResponse>> Handle(GetNarratorByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.NarratorRepository
                .GetQueryable()
                .Where(n => n.Id == request.Id)
                .AsNoTracking()
                .AsSplitQuery()
                .ProjectToType<NarratorDetailsResponse>()
                .FirstOrDefaultAsync(cancellationToken);

            if (response is null)
                return Result<NarratorDetailsResponse>.Failure(Errors.NarratorNotFound);
            return Result<NarratorDetailsResponse>.Success(response);
        }

    }
}