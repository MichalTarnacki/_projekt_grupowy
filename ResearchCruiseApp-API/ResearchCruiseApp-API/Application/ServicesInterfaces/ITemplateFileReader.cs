namespace ResearchCruiseApp_API.Application.ServicesInterfaces;


public interface ITemplateFileReader
{
    Task<string> ReadEmailConfirmationMessageTemplate();
    Task<string> ReadAccountAcceptedMessageTemplate();
    Task<string> ReadEmailConfirmationEmailSubject();
    Task<string> ReadAccountAcceptedEmailSubject();
}