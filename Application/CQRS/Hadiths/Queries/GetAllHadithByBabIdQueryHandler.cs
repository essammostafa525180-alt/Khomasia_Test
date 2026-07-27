using Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.CQRS.Hadiths.Queries
{
    public class GetAllHadithByBabIdQuery : IQuery<Result<HadithContantResponse>>
    {
        public int BabId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllHadithByBabIdQueryHandler :
        IQueryHandler<GetAllHadithByBabIdQuery, Result<HadithContantResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _http;
        private readonly IConfiguration _configuration;

        public GetAllHadithByBabIdQueryHandler(
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IHttpContextAccessor http)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _http = http;
        }
        public async Task<Result<HadithContantResponse>> Handle(
    GetAllHadithByBabIdQuery request,
    CancellationToken cancellationToken)
        {
            var httpRequest = _http.HttpContext!.Request;
            var baseAudioUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/hadith/audio/";

            var info = await _unitOfWork.BabRepository.GetQueryable()
                .AsNoTracking()
                .Where(b => b.Id == request.BabId)
                .Select(b => new HadithContantResponse
                {
                    BabId = b.Id,
                    BabName = b.Name,
                    BookId = b.BookId ?? 0,
                    BookName = b.Book.Name,
                    ClassificationId = b.Book.ClassificationId ?? 0,
                    ClassificationName = b.Book.Classification.Name,
                    Hadiths = b.Hadiths
                        .OrderBy(h => h.HadithNumber)
                        .ThenBy(h => h.Id)
                        .Select(h => new HadithListResponse
                        {
                            Id = h.Id,
                            Matn = h.Matn,
                            HadithWithSign = h.HadithWithSign,
                            HadithWithNoSign = h.HadithWithNoSign,
                            IsAvailable = h.AudioUrl != null && h.AudioUrl != "",
                            AudioUrl = h.AudioUrl != null && h.AudioUrl != ""
                                ? baseAudioUrl + h.Id + ".mp3"
                                : null
                        })
                        .ToList()
                })
                .AsSplitQuery() // 🔥 مهم لتقليل الضغط
                .FirstOrDefaultAsync(cancellationToken);

            return Result<HadithContantResponse>.Success(info);
        }

        //public async Task<Result<HadithContantResponse>> Handle(
        //    GetAllHadithByBabIdQuery request,
        //    CancellationToken cancellationToken)
        //{
        //    var httpRequest = _http.HttpContext!.Request;
        //    var baseAudioUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/hadith/audio/";

        //    // جلب معلومات الباب والكتاب والتصنيف
        //    var info = await _unitOfWork.BabRepository.GetQueryable()
        //        .AsNoTracking()
        //        .Where(b => b.Id == request.BabId)
        //        .Select(b => new HadithContantResponse
        //        {
        //            BabId = b.Id,
        //            BabName = b.Name,
        //            BookId = b.BookId ?? 0,
        //            BookName = b.Book.Name,
        //            ClassificationId = b.Book.ClassificationId ?? 0,
        //            ClassificationName = b.Book.Classification.Name,
        //            Hadiths = new List<HadithListResponse>()
        //        })
        //        .FirstOrDefaultAsync(cancellationToken);

        //    if (info == null) return Result<HadithContantResponse>.Success(null);

        //    // جلب الأحاديث الرئيسية
        //    var hadith = await _unitOfWork.HadithRepository.GetQueryable()
        //        .AsNoTracking()
        //        .Where(h => h.BabId == request.BabId)
        //        .ProjectToType<HadithListResponse>()
        //        .ToListAsync(cancellationToken);

        //    // جلب الأحاديث الناقصة
        //    var hadithMissing = await _unitOfWork.HadithMissingRepository.GetQueryable()
        //        .AsNoTracking()
        //        .Where(h => h.BabId == request.BabId)
        //        .OrderBy(H => H.HadithNumber)
        //        .ProjectToType<HadithListResponse>()
        //        .ToListAsync(cancellationToken);

        //    // دمج الأحاديث بعد الضبط على AudioUrl و IsAvailable
        //    info.Hadiths = PrepareHadiths(hadith, baseAudioUrl)
        //                   .Concat(PrepareHadiths(hadithMissing, baseAudioUrl))
        //                   .OrderBy(h => h.Id)
        //                   .ToList();

        //    return Result<HadithContantResponse>.Success(info);
        //}

        // دالة مساعدة لضبط AudioUrl و IsAvailable
        private static List<HadithListResponse> PrepareHadiths(List<HadithListResponse> list, string baseAudioUrl)
        {
            return list.Select(h =>
            {
                h.IsAvailable = !string.IsNullOrEmpty(h.AudioUrl);
                if (h.IsAvailable)
                    h.AudioUrl = baseAudioUrl + $"{h.Id}.mp3";
                return h;
            }).ToList();
        }
    }

    //public async Task<Result<HadithContantResponse>> Handle(
    //    GetAllHadithByBabIdQuery request,
    //    CancellationToken cancellationToken)
    //{
    //    // base URL للصوت
    //    var httpRequest = _http.HttpContext!.Request;
    //    var baseAudioUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/hadith/audio/";

    //    // الأحاديث اللي ناقصة
    //    var hadithMissing = await _unitOfWork.HadithMissingRepository
    //        .GetQueryable()
    //        .AsNoTracking()
    //        .Where(h => h.BabId == request.BabId)
    //        .ProjectToType<HadithListResponse>()
    //        .ToListAsync(cancellationToken);

    //    // الضبط على AudioUrl و IsAvailable للأحاديث الناقصة
    //    hadithMissing = hadithMissing
    //        .Select(h =>
    //        {
    //            h.IsAvailable = !string.IsNullOrEmpty(h.AudioUrl);
    //            if (h.IsAvailable)
    //                h.AudioUrl = baseAudioUrl + $"{h.Id}.mp3";
    //            return h;
    //        })
    //        .ToList();

    //    // الأحاديث الرئيسية
    //    var result = await _unitOfWork.HadithRepository
    //        .GetQueryable()
    //        .AsNoTracking()
    //        .Where(s => s.BabId == request.BabId)
    //        .GroupBy(s => new
    //        {
    //            BabId = s.BabId,
    //            BabName = s.Bab.Name,
    //            BookId = s.Bab.BookId,
    //            BookName = s.Bab.Book.Name,
    //            ClassificationId = s.Bab.Book.ClassificationId,
    //            ClassificationName = s.Bab.Book.Classification.Name
    //        })
    //        .Select(g => new HadithContantResponse
    //        {
    //            ClassificationId = g.Key.ClassificationId ?? 0,
    //            ClassificationName = g.Key.ClassificationName,
    //            BookId = g.Key.BookId ?? 0,
    //            BookName = g.Key.BookName,
    //            BabId = g.Key.BabId ?? 0,
    //            BabName = g.Key.BabName,
    //            Hadiths = g.Select(s => new HadithListResponse
    //            {
    //                Id = s.Id,
    //                Matn = s.Matn,
    //                HadithWithSign = s.HadithWithSign,
    //                HadithWithNoSign = s.HadithWithNoSign,
    //                IsAvailable = s.IsAvailable,
    //                AudioUrl = string.IsNullOrEmpty(s.AudioUrl) ? null : baseAudioUrl + s.AudioUrl
    //            }).ToList()
    //        })
    //        .FirstOrDefaultAsync(cancellationToken);

    //    // دمج الأحاديث الناقصة
    //    if (result != null)
    //    {
    //        result.Hadiths = result.Hadiths
    //            .Concat(hadithMissing)
    //            .OrderBy(h => h.Id)
    //            .ToList();
    //    }

    //    return Result<HadithContantResponse>.Success(result);
    //}

}
