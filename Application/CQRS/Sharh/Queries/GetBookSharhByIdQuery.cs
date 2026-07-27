using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sharh.Queries
{

    public class GetBookSharhByIdQuery
: IQuery<Result<SharhClassifacationResponse>>
    {
        public int Id { get; set; }
    }
    public class GetBookSharhByIdQueryHandler
         : IQueryHandler<GetBookSharhByIdQuery, Result<SharhClassifacationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookSharhByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SharhClassifacationResponse>> Handle(
     GetBookSharhByIdQuery request,
     CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.SharhBookRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(sb => sb.Id == request.Id)
                .OrderBy(h => h.Id)
                .AsSplitQuery()
                .ProjectToType<SharhClassifacationResponse>()
                .FirstOrDefaultAsync(cancellationToken);

            if (response is null)
                return Result<SharhClassifacationResponse>.Failure(Errors.SharhNotFound);

            return Result<SharhClassifacationResponse>.Success(response);
        }

    }

}

