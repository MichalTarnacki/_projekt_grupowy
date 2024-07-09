using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Data;
using ResearchCruiseApp_API.Models;
using ResearchCruiseApp_API.Tools;
using ResearchCruiseApp_API.Types;

namespace ResearchCruiseApp_API.Controllers
{
    [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.Shipowner}")]
    [Route("api/[controller]")]
    [ApiController]
    public class CruisesController(
        ResearchCruiseContext researchCruiseContext,
        UserManager<User> userManager,
        IYearBasedKeyGenerator yearBasedKeyGenerator,
        IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCruises()
        {
            var cruises = await researchCruiseContext.Cruises
                .Include(cruise => cruise.Applications)
                .ToListAsync();

            var cruisesModels = cruises
                .Select(mapper.Map<CruiseModel>)
                .ToList();

            return Ok(cruisesModels);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> EditCruise(Guid id, EditCruiseModel editCruiseModel)
        {
            var cruise = await researchCruiseContext.Cruises
                .Include(cruise => cruise.Applications)
                .Where(cruise => cruise.Id == id)
                .FirstOrDefaultAsync();

            if (cruise == null)
                return NotFound();
            
            var startDateUtc = DateTime.ParseExact(
                editCruiseModel.Date.Start,
                "yyyy-MM-ddTHH:mm:ss.fffK",
                null,
                System.Globalization.DateTimeStyles.RoundtripKind);
            var endDateUtc = DateTime.ParseExact(
                editCruiseModel.Date.End,
                "yyyy-MM-ddTHH:mm:ss.fffK",
                null,
                System.Globalization.DateTimeStyles.RoundtripKind);

            cruise.StartDate = TimeZoneInfo.ConvertTimeFromUtc(startDateUtc, TimeZoneInfo.Local);
            cruise.EndDate = TimeZoneInfo.ConvertTimeFromUtc(endDateUtc, TimeZoneInfo.Local);

            var newMainCruiseManager =
                await userManager.FindByIdAsync(editCruiseModel.ManagersTeam.MainCruiseManagerId.ToString());
            var newMainDeputyManager =
                await userManager.FindByIdAsync(editCruiseModel.ManagersTeam.MainDeputyManagerId.ToString());

            if (newMainCruiseManager == null || newMainDeputyManager == null)
                return NotFound();

            cruise.MainCruiseManagerId = Guid.Parse(newMainCruiseManager.Id);
            cruise.MainDeputyManagerId = Guid.Parse(newMainDeputyManager.Id);

            var newCruiseApplicationsQuery = researchCruiseContext.Applications
                .Where(application => editCruiseModel.ApplicationsIds.Contains(application.Id));
            
            // Cruises that already contain any of newCruiseApplications. The application will be deleted from them
            // since an application cannot be assigned to more than one cruise
            var affectedCruises = researchCruiseContext.Cruises
                .Include(affectedCruise => affectedCruise.Applications)
                .Where(affectedCruise => newCruiseApplicationsQuery.Any(newApp =>
                    affectedCruise.Applications.Contains(newApp)))
                .ToList();
            if (!affectedCruises.Contains(cruise))
            {
                affectedCruises = affectedCruises
                    .Append(cruise) // The explicitly edited cruise is of course also affected
                    .ToList();
            }

            cruise.Applications = await newCruiseApplicationsQuery.ToListAsync();
            
            await CheckEditedCruisesManagersTeams(affectedCruises);
            
            await researchCruiseContext.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPut("autoAdded")]
        public async Task<IActionResult> AutoAddCruises()
        {
            var applications = await researchCruiseContext.Applications
                .Include(application => application.FormA)
                .ToListAsync();
            var cruises = researchCruiseContext.Cruises;
        
            foreach (var application in applications)
            {
                if (application.FormA == null)
                    continue;
        
                var cruiseDates = GetAutoCalculatedCruiseDate(application.FormA);
                var newCruise = new Cruise
                {
                    MainCruiseManagerId = application.FormA.CruiseManagerId,
                    MainDeputyManagerId = application.FormA.DeputyManagerId,
                    StartDate = cruiseDates.Item1,
                    EndDate = cruiseDates.Item2,
                    Applications = [application]
                };
                
                // Using transaction to prevent multiple users from generating a cruise with the same number
                await using var transaction =
                    await researchCruiseContext.Database.BeginTransactionAsync(
                        System.Data.IsolationLevel.Serializable);
                try
                {
                    newCruise.Number = yearBasedKeyGenerator.GenerateKey(researchCruiseContext.Cruises);
                    cruises.Add(newCruise);
        
                    await researchCruiseContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        
        
            return NoContent();
        }
        
        
        private static Tuple<DateTime, DateTime> GetAutoCalculatedCruiseDate(FormA formA)
        {
            // Optimal period beg/end is a number from range 0...24 representing a point in a year
            
            var startDay = formA.OptimalPeriodBeg % 2 == 0 ?
                1 : // start at the beginning of a month 
                15; // start at the middle of a month
            var startMonth = formA.OptimalPeriodBeg / 2 + 1;
            
            var startDate = new DateTime(formA.Year, startMonth, startDay, 8, 0, 0);
            var endDate = startDate.AddHours(formA.CruiseHours);
        
            return new Tuple<DateTime, DateTime>(startDate, endDate);
        }

        private async Task CheckEditedCruisesManagersTeams(List<Cruise> cruises)
        {
            foreach (var cruise in cruises)
            {
                foreach (var application in cruise.Applications)
                {
                    await researchCruiseContext.Entry(application)
                        .Reference(applicationEntry => applicationEntry.FormA)
                        .LoadAsync();
                }
                    
                if (cruise.Applications.Any(app => app.FormA == null))
                    continue;

                var managersAvailable = cruise.Applications
                    .Select(app => app.FormA!.CruiseManagerId)
                    .Union(cruise.Applications
                        .Select(app => app.FormA!.DeputyManagerId))
                    .ToList();

                if (!managersAvailable.Contains(cruise.MainCruiseManagerId))
                    cruise.MainCruiseManagerId = Guid.Empty;
                if (!managersAvailable.Contains(cruise.MainDeputyManagerId))
                    cruise.MainDeputyManagerId = Guid.Empty;
            }
        }
    }
}
