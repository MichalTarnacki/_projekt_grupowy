namespace ResearchCruiseApp_API.Application.ExternalServices;


public interface ITemplateFileReader
{
    Task<string> ReadEmailConfirmationMessageTemplate();
    Task<string> ReadAccountAcceptedMessageTemplate();
    Task<string> ReadRequestToSupervisorMessageTemplate();
    Task<string> ReadEmailConfirmationEmailSubject();
    Task<string> ReadAccountAcceptedEmailSubject();
    Task<string> ReadRequestToSupervisorEmailSubject();
}