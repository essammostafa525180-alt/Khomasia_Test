namespace Application.CQRS.ContactMessages.Request_Response
{

    public record CreateContactMessageRequest(
      string Name,
      string Email,
      string? Subject,
      string Message
  );
}
