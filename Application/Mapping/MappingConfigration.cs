//using Application.CQRS.Books;
//using Application.CQRS.Hadiths;
//using Application.CQRS.Sharh;

//using Mapster;

//namespace Application.Mapping
//{
//    public class MappingConfigration : IRegister
//    {
//        public void Register(TypeAdapterConfig config)
//        {



//            config.NewConfig<Book, BookListResponse>()
//                .Map(dest => dest.BabCount, src => src.Babs.Count());


//            config.NewConfig<Book, BookDetailsWithBabsResponse>()
//                .Map(dest => dest.ClassificationName, src => src.Classification.Name)
//                .Map(dest => dest.ClassificationId, src => src.ClassificationId);


//            config.NewConfig<SharhBook, SharhBookMetaResponse>()
//      .Map(dest => dest.SharhBookId, src => src.Id)
//      .Map(dest => dest.SharhBookName, src => src.Name)
//      //.Map(dest => dest.SharhBookAuthor, src => src.Name)
//      .Map(dest => dest.ClassificationId, src => src.ClassificationRefrenaceId)
//      .Map(dest => dest.ClassificationName, src => src.ClassificationRefrenace.Name)
//      .Map(dest => dest.BookCount, src => src.ClassificationRefrenace.Books.Count())
//      .Map(dest => dest.BabCount, src => src.ClassificationRefrenace.Books.SelectMany(b => b.Babs).Count())
//      .Map(dest => dest.HadithCount, src => src.ClassificationRefrenace.Books
//          .SelectMany(b => b.Babs)
//          .SelectMany(b => b.Hadiths)
//          .Count());



//            config.NewConfig<Bab, HadithMetaResponse>()
//                .Map(dest => dest.BabId, src => src.Id)
//                .Map(dest => dest.BabName, src => src.Name)
//                .Map(dest => dest.BookId, src => src.BookId)
//                .Map(dest => dest.BookName, src => src.Book.Name)
//                .Map(dest => dest.ClassificationName, src => src.Book.Classification.Name)
//                .Map(dest => dest.ClassificationId, src => src.Book.ClassificationId)
//                .Map(dest => dest.ClassificationName, src => src.Book.Classification.Name);







//            config.NewConfig<HadithMissing, HadithListResponse>()
//                .Map(dest => dest.Id, src => src.SelId);


//            config.NewConfig<HadithTakhreej, TakhreejContantListResponse>()
//                .Map(dest => dest.ClassificationId, src => src.HadithTo.Bab.Book.ClassificationId)
//                .Map(dest => dest.ClassificationName, src => src.HadithTo.Bab.Book.Classification.Name)

//                .Map(dest => dest.BookId, src => src.HadithTo.Bab.BookId)
//                .Map(dest => dest.BookIndex, src => src.HadithTo.Bab.Book.ClassificationIndex)
//                .Map(dest => dest.BookName, src => src.HadithTo.Bab.Book.Name)

//                .Map(dest => dest.BabId, src => src.HadithTo.BabId)
//                .Map(dest => dest.BabIndex, src => src.HadithTo.Bab.BabIndex)
//                .Map(dest => dest.BabName, src => src.HadithTo.Bab.Name)

//                //.Map(dest => dest.HadithIdFrom, src => src.HadithIdFrom)
//                .Map(dest => dest.HadithFromNumber, src => src.HadithFrom.HadithNumber)
//                .Map(dest => dest.HadithTextFrom, src => src.HadithFrom.HadithWithSign)

//                //.Map(dest => dest.HadithToId, src => src.HadithIdTo)
//                .Map(dest => dest.HadithToNumber, src => src.HadithTo.HadithNumber)
//                .Map(dest => dest.HadithTextTo, src => src.HadithTo.HadithWithSign);

//            //config.NewConfig<Classification, ClassificationSummaryResponse>();
//            //config.NewConfig<Classification, ClassificationDetailsResponse>();

//            //config.NewConfig<Book, BookSummaryResponse>();




//            config.NewConfig<SharhBook, SharhClassifacationResponse>()
//                .Map(dest => dest.Books, src => src.ClassificationRefrenace.Books);

//            config.NewConfig<Hadith, HadithContantResponse>()
//       .Map(dest => dest.ClassificationId,
//            src => src.Bab != null && src.Bab.Book != null
//                ? src.Bab.Book.ClassificationId
//                : null)

//       .Map(dest => dest.ClassificationName,
//            src => src.Bab != null && src.Bab.Book != null && src.Bab.Book.Classification != null
//                ? src.Bab.Book.Classification.Name
//                : null)

//       .Map(dest => dest.BookId,
//            src => src.Bab != null ? src.Bab.BookId : null)

//       .Map(dest => dest.BookName,
//            src => src.Bab != null && src.Bab.Book != null
//                ? src.Bab.Book.Name
//                : null)

//       .Map(dest => dest.BabId, src => src.BabId)

//       .Map(dest => dest.BabName,
//            src => src.Bab != null ? src.Bab.Name : null);




//            // Mapping من Hadith → SearchResultResponse
//            config.NewConfig<Hadith, SearchResultResponse>()

//                .Map(dest => dest.ClassificationId, src => src.Bab.Book.ClassificationId)
//                .Map(dest => dest.ClassificationName, src => src.Bab.Book.Classification.Name)
//                .Map(dest => dest.BookId, src => src.Bab.Book.Id)
//                .Map(dest => dest.BookName, src => src.Bab.Book.Name)
//                .Map(dest => dest.BabId, src => src.Bab.Id)
//                .Map(dest => dest.BabName, src => src.Bab.Name)
//                .Map(dest => dest.Hadith, src => src);







//        }
//    }
//}
