//using Application.Abstractions;
//using Microsoft.Extensions.Localization;

//namespace Application.CQRS.Bab.Commands
//{
//    public class DeleteHadithCommand : ICommand<Result<int>>
//    {
//        public int Id { get; set; }
//    }
//    internal class DeleteHadithCommandHandler : ICommandHandler<DeleteHadithCommand, Result<int>>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;

//        public DeleteHadithCommandHandler(IUnitOfWork unitOfWork,
//            IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
//        {
//            _unitOfWork = unitOfWork;
//            _sharedLocalizer = sharedLocalizer;
//        }



//        public async Task<Result<int>> Handle(DeleteHadithCommand request, CancellationToken cancellationToken)
//        {
//            var hadith = await _unitOfWork.HadithRepository.GetByIdAsync(request.Id);
//            if (hadith == default || hadith.IsDeleted)
//                return Result<int>.Failure(
//                 _sharedLocalizer[string.Format(_sharedLocalizer["{0} NotFound"],
//                 _sharedLocalizer[Errors.Hadith])]);

//            _unitOfWork.HadithRepository.SoftDelete(hadith);
//            hadith.DeletedAt = DateTime.Now;
//            int isDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken);
//            return isDeleted > 0
//                    ? Result<int>.Success(request.Id)
//                    : Result<int>.Failure(Errors.HadithNotDeleted);
//        }


//    }

//}