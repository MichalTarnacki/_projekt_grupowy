namespace ResearchCruiseApp_API.Application.ServicesInterfaces;


public interface ITemplateFileReader
{
    Task<string> ReadEmailConfirmationMessageTemplateAsync();
    Task<string> ReadEmailConfirmationEmailSubjectAsync();
}