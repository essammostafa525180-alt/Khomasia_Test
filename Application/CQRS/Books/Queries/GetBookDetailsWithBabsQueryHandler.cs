using Application.Abstractions;
using Application.Response;
using Domain.Aggregates.BookAggregate;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Queries
{
    public class GetBookDetailsWithBabsQuery
       : IQuery<Result<Navigation<BookDetailsWithBabsResponse>>>
    {
        public int Id { get; set; }
    }

    public class GetBookDetailsWithBabsQueryHandler :
        IQueryHandler<GetBookDetailsWithBabsQuery,
            Result<Navigation<BookDetailsWithBabsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookDetailsWithBabsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<Navigation<BookDetailsWithBabsResponse>>> Handle(GetBookDetailsWithBabsQuery request, CancellationToken cancellationToken)
        {
            // جلب الكتاب الحالي أولاً
            var currentBook = await _unitOfWork.BookRepository.GetQueryable()
                .Include(b => b.Classification)
                .Include(b => b.Babs)
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (currentBook is null)
                return Result<Navigation<BookDetailsWithBabsResponse>>.Failure(Errors.BookNotFound);

            // جلب الكتب اللي بنفس التصنيف فقط
            var booksQuery = _unitOfWork.BookRepository.GetQueryable()
                .Where(b => b.ClassificationId == currentBook.ClassificationId)
                .Include(b => b.Classification)
                .Include(b => b.Babs);

            // إنشاء الـ Navigation
            var bookNavigation = await Navigation<Book>.CreateAsync(
                booksQuery,
                request.Id,
                b => b.Id,
                cancellationToken
            );

            // تجهيز الـ Response
            var response = new Navigation<BookDetailsWithBabsResponse>
            {
                PreviousId = bookNavigation.PreviousId,
                NextId = bookNavigation.NextId,
                Data = currentBook.Adapt<BookDetailsWithBabsResponse>()
            };

            return Result<Navigation<BookDetailsWithBabsResponse>>.Success(response);
        }
        ////  نجيب   classificationId للكتاب المطلوب
        //var classificationId = await _unitOfWork.BookRepository
        //    .GetQueryable()
        //    .Where(b => b.Id == request.Id)
        //    .Select(b => b.ClassificationId)
        //    .FirstOrDefaultAsync(cancellationToken);

        //if (classificationId is null)
        //    return Result<Navigation<BookDetailsWithBabsResponse>>
        //        .Failure(Errors.BookNotFound);

        ////  هجيب كل الكتب في نفس التصنيف 
        //var baseQuery = _unitOfWork.BookRepository
        //    .GetQueryable()
        //    .AsNoTracking()
        //    .Include(b => b.Babs)
        //    .AsSplitQuery()
        //    .Where(b => b.ClassificationId == classificationId);

        //// نجيب ال Navigation  
        //var navigation = await Navigation<Book>.CreateAsync(baseQuery, request.Id, b => b.Id, cancellationToken);

        //if (navigation is null)
        //    return Result<Navigation<BookDetailsWithBabsResponse>>
        //        .Failure(Errors.BookNotFound);

        //// Mapster 
        //var response = new Navigation<BookDetailsWithBabsResponse>
        //{
        //    PreviousId = navigation.PreviousId,
        //    NextId = navigation.NextId,
        //    Data = navigation.Data.Adapt<BookDetailsWithBabsResponse>()
        //};

        //return Result<Navigation<BookDetailsWithBabsResponse>>.Success(response);


        //public async Task<Result<Navigation<BookDetailsWithBabsResponse>>> Handle(
        //    GetBookDetailsWithBabsQuery request,
        //    CancellationToken cancellationToken)
        //{
        //    // جلب الكتاب الحالي أولاً
        //    var currentBook = await _unitOfWork.BookRepository.GetQueryable()
        //        .Include(b => b.Classification)
        //        .Include(b => b.Babs)
        //        .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        //    if (currentBook is null)
        //        return Result<Navigation<BookDetailsWithBabsResponse>>.Failure(Errors.BookNotFound);

        //    // جلب الكتب اللي بنفس التصنيف فقط
        //    var booksQuery = _unitOfWork.BookRepository.GetQueryable()
        //        .Where(b => b.ClassificationId == currentBook.ClassificationId)
        //        .Include(b => b.Classification)
        //        .Include(b => b.Babs);

        //    // إنشاء الـ Navigation
        //    var bookNavigation = await Navigation<Book>.CreateAsync(
        //        booksQuery,
        //        request.Id,
        //        b => b.Id,
        //        cancellationToken
        //    );

        //    // تجهيز الـ Response
        //    var response = new Navigation<BookDetailsWithBabsResponse>
        //    {
        //        PreviousId = bookNavigation.PreviousId,
        //        NextId = bookNavigation.NextId,
        //        Data = currentBook.Adapt<BookDetailsWithBabsResponse>()
        //    };

        //    return Result<Navigation<BookDetailsWithBabsResponse>>.Success(response);
        //}



    }
}
