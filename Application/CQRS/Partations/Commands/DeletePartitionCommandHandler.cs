using Application.Abstractions;

namespace Application.CQRS.Bab.Commands
{
    public class DeletePartitionCommand : ICommand<Result>
    {
        public int Id { get; set; }
    }
    public class DeletePartitionCommandHandler
         : ICommandHandler<DeletePartitionCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePartitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            DeletePartitionCommand request,
            CancellationToken cancellationToken)
        {
            var partition = await _unitOfWork.PartitionRepository
                .GetByIdAsync(request.Id);

            if (partition is not { IsDeleted: true })
                return Result.Failure(Errors.PartitionNotFound);

            _unitOfWork.PartitionRepository.SoftDelete(partition);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0 ? Result.Success() : Result.Failure(Errors.PartitionNotDeleted);
        }
    }
}