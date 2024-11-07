using System.Globalization;

namespace ResearchCruiseApp_API.Application.ExternalServices;


public interface ICultureService
{
    CultureInfo GetCultureInfo();

    TimeZoneInfo GetTimeZoneInfo();
}