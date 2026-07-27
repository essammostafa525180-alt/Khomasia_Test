
//using Application.Abstractions;
//using Domain.Entities;

//namespace Application.CQRS.Partations
//{
//    public class CreatePartationCommand : ICommand<Result<PartitionDetailsResponse>>
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }

//        public bool IsActive { get; set; }
//        public bool HasHadithCollection { get; set; }

//    };


//    internal class CreatePartationCommandHandler
//        : ICommandHandler<CreatePartationCommand, Result<PartitionDetailsResponse>>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public CreatePartationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<Result<PartitionDetailsResponse>> Handle(CreatePartationCommand request, CancellationToken cancellationToken)
//        {

//            var newPartation = Partation.Create(request.Name, request.HasHadithCollection);

//            await _unitOfWork.PartitionRepository.AddAsync(newPartation);

//            var insertedId = await _unitOfWork.SaveChangesAsync(cancellationToken);

//            var partationDetailsDto = _mapper.Map<Partation, PartitionDetailsResponse>(newPartation);

//            return insertedId > 0
//                ? Result<PartitionDetailsResponse>.Success(partitionDetailsResponse)
//                : Result<PartitionDetailsResponse>.Failure(Errors.PartitionNotInserted);
//        }
//    };
//}
