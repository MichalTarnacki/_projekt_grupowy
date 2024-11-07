using System.Globalization;
using ResearchCruiseApp_API.Application.ExternalServices;

namespace ResearchCruiseApp_API.Infrastructure.Services;


public class CultureService : ICultureService
{
    private const string CultureInfoId = "pl-pl";
    private const string TimeZoneInfoId = "Central European Standard Time";
    
    
    public CultureInfo GetCultureInfo() => new CultureInfo(CultureInfoId);

    public TimeZoneInfo GetTimeZoneInfo() => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfoId);
}