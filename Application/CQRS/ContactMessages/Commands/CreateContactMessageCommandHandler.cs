using Application.Abstractions;
using Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.ContactMessages.Commands
{
    public class CreateContactMessageCommand : ICommand<Result<int>>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public string? PageUrl { get; set; }
    }
    internal class CreateContactMessageCommandHandler : ICommandHandler<CreateContactMessageCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _emailTemplateService;

        public CreateContactMessageCommandHandler(IUnitOfWork unitOfWork,
            IStringLocalizer<Resources.Resources.Shared> sharedLocalizer,
            IEmailSender emailSender,
            IEmailTemplateService emailTemplateService)
        {
            _unitOfWork = unitOfWork;
            _sharedLocalizer = sharedLocalizer;
            _emailSender = emailSender;
            _emailTemplateService = emailTemplateService;
        }



        public async Task<Result<int>> Handle(CreateContactMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = ContactMessage.Create(
                   request.Name,
                   request.Email,
                   request.Message,
                   request.Subject,
                   request.PageUrl,
                   !string.IsNullOrWhiteSpace(request.PageUrl)
               );


            await _unitOfWork.ContactMessageRepository.AddAsync(entity);
            var resulat = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (resulat > 0)
            {
                string emailBody;
                if (!string.IsNullOrWhiteSpace(request.PageUrl))
                {
                    emailBody = await _emailTemplateService.GetHadithNoteEmailBodyAsync(request.PageUrl, request.Email, request.Message);
                }
                else
                {
                    emailBody = await _emailTemplateService.GetContactUsEmailBodyAsync(request.Name, request.Email, request.Subject, request.Message);
                }

                await _emailSender.SendEmailAsync(request.Email, request.Subject, emailBody);
                return Result<int>.Success(entity.Id);
            }

            return Result<int>.Failure(Errors.MessageNotInserted);

        }
    }
}