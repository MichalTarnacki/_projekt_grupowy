using System.Text;
using FluentValidation;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.AddCruiseApplication;


public class AddCruiseApplicationValidator : AbstractValidator<AddCruiseApplicationCommand>
{
    public AddCruiseApplicationValidator()
    {
        RuleForEach(command => command.FormADto.Contracts)
            .Must(contractDto =>
            {
                const string pdfBase64UrlPrefix = "data:application/pdf;base64,"; 
                var pdfBase64UrlPrefixLength = pdfBase64UrlPrefix.Length;
                const int fileHeaderLength = 4;
                const string pdfFileHeaderString = "%PDF";

                var scanContentWithoutPrefix = string.Concat(
                    contractDto.Scan.Content.Skip(pdfBase64UrlPrefixLength)
                );
                
                try
                { 
                    var scanBytes = Convert.FromBase64String(scanContentWithoutPrefix);
                    var scanFileHeader = Encoding.ASCII.GetString(scanBytes
                        .Take(fileHeaderLength)
                        .ToArray()
                    );

                    return scanFileHeader == pdfFileHeaderString;
                }
                catch (FormatException)
                {
                    return false;
                }
            })
            .WithMessage("Skan umowy musi być plikiem PDF.");
    }
}