using System.Globalization;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Domain.Common.Constants;

namespace ResearchCruiseApp_API.Infrastructure.Services;


public class GlobalizationService : IGlobalizationService
{
    private const string CultureInfoId = "pl-pl";
    private const string TimeZoneInfoId = "Central European Standard Time";
    
    
    public CultureInfo GetCultureInfo() => new CultureInfo(CultureInfoId);

    public TimeZoneInfo GetTimeZoneInfo() => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfoId);

    public string GetIsoUtcString(DateTime date)
    {
        if (date.Kind != DateTimeKind.Unspecified)
            date = DateTime.SpecifyKind(date, DateTimeKind.Unspecified);
        
        var timeZoneInfo = GetTimeZoneInfo();
        var dateUtc = TimeZoneInfo.ConvertTimeToUtc(date, timeZoneInfo);
        var dateString = dateUtc.ToString(DateConstants.IsoStringDateFormat);

        return dateString;
    }
}