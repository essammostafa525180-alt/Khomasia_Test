using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sharh.Queries
{
    public class GetOtherBookSharhByHadithIdQuery
: IQuery<Result<List<OtherBookSharhHadithContantResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int HadithId { get; set; }
    }
    public class GetOtherBookSharhByHadithIdQueryHandler
         : IQueryHandler<GetOtherBookSharhByHadithIdQuery, Result<List<OtherBookSharhHadithContantResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOtherBookSharhByHadithIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<OtherBookSharhHadithContantResponse>>> Handle(
           GetOtherBookSharhByHadithIdQuery request,
            CancellationToken cancellationToken)
        {

            var hadiths = _unitOfWork.HadithTakhreejRepository
    .GetQueryable()
    .AsNoTracking()
    .Where(t => t.HadithIdFrom == request.HadithId)
    .Select(t => t.HadithTo)
    .Union(
        _unitOfWork.HadithTakhreejRepository
            .GetQueryable()
            .AsNoTracking()
            .Where(t => t.HadithIdTo == request.HadithId)
            .Select(t => t.HadithFrom)
    );

            var result = await hadiths
    .Where(h => h.HadithSharh.Any())
    .SelectMany(h => h.HadithSharh, (h, sh) => new { Hadith = h, Sharh = sh })
    .GroupBy(x => new
    {
        x.Sharh.SharhBook.Id,
        x.Sharh.SharhBook.Name
    })
    .Select(g => new OtherBookSharhHadithContantResponse(
        g.Key.Id,
        g.Key.Name,
        g.GroupBy(x => new
        {
            x.Hadith.Id,
            x.Hadith.HadithNumber
        })
        .Select(hg => new HadithSharhBookContant(
            hg.Key.Id,
            hg.Key.HadithNumber
        ))
        .ToList()
    ))
    .ToListAsync(cancellationToken);
            //        var result = await _unitOfWork.HadithTakhreejRepository
            //.GetQueryable()
            //.AsNoTracking()
            //.Where(t => t.HadithIdFrom == request.HadithId)
            //.Select(t => t.HadithTo)
            //.Where(h => h.HadithSharh.Any()) // حديث فيه شروح
            //.SelectMany(h => h.HadithSharh, (h, sh) => new { Hadith = h, Sharh = sh })
            //.GroupBy(x => new { x.Sharh.SharhBook.Id, x.Sharh.SharhBook.Name })
            //.Select(g => new OtherBookSharhHadithContantResponse(
            //    g.Key.Id,
            //    g.Key.Name,
            //    g.GroupBy(x => new { x.Hadith.Id, x.Hadith.HadithNumber })
            //     .Select(hg => new HadithSharhBookContant(
            //         hg.Key.Id,
            //         hg.Key.HadithNumber

            //     ))
            //     .ToList()
            //))
            //.ToListAsync(cancellationToken);



            if (result is null)
                return Result<List<OtherBookSharhHadithContantResponse>>.Failure(Errors.SharhNotFound);


            return Result<List<OtherBookSharhHadithContantResponse>>.Success(result);
        }
    }
}

// var result = await _unitOfWork.HadithTakhreejRepository
//.GetQueryable()
//.AsNoTracking()
//.Where(t => t.HadithIdFrom == request.HadithId)
//.Select(t => t.HadithTo)
//.Where(h => h.HadithSharh.Any()) // حديث فيه شروح
//.SelectMany(h => h.HadithSharh, (h, sh) => new { Hadith = h, Sharh = sh })
//.GroupBy(x => new { x.Sharh.SharhBook.Id, x.Sharh.SharhBook.Name })
//.Select(g => new OtherBookSharhHadithContantResponse(
//    g.Key.Id,
//    g.Key.Name,
//    g.GroupBy(x => new { x.Hadith.Id, x.Hadith.HadithNumber })
//     .Select(hg => new HadithSharhBookContant(
//         hg.Key.Id,
//         hg.Key.HadithNumber,
//         hg.Select(s => new SharhContantResponse(
//             s.Sharh.SharhWithSign,
//             s.Sharh.SharhWithNoSign
//         )).ToList()
//     ))
//     .ToList()
//))
//.ToListAsync(cancellationToken);

//}