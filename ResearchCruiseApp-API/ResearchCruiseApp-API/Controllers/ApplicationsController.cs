using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Data;
using ResearchCruiseApp_API.Models;
using ResearchCruiseApp_API.Tools;
using ResearchCruiseApp_API.Types;
using ResearchCruiseApp_API.Controllers;

namespace ResearchCruiseApp_API.Controllers
{
    [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.Shipowner}")]
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController(ResearchCruiseContext researchCruiseContext, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await GetAllApplicationsFromDb()
                .ToListAsync();
            
            var applicationModels = applications
                .Select(mapper.Map<ApplicationModel>)
                .ToList();

            return Ok(applicationModels);
        }

        public Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ResearchCruiseApp_API.Data.Application,ResearchCruiseApp_API.Data.FormC?> GetAllApplicationsFromDb()
        {
            return researchCruiseContext.Applications
                .Include(application => application.FormA)
                .Include(application => application.FormB)
                .Include(application => application.FormC);
        }
        
        public GetAllCruiseEffectsFromDb()
        {
            return researchCruiseContext.CruiseEffects
                .Include(application => application.FormA)
                .Include(application => application.FormB)
                .Include(application => application.FormC);
        }

        [HttpGet("{applicationId:guid}")]
        public async Task<IActionResult> CalculatePoints([FromRoute] Guid applicationId)
        {
            var application = await GetAllApplicationsFromDb()
                .FirstOrDefaultAsync(application => application.Id == applicationId);
            if (application == null)
                return NotFound();
            
            return Ok(new EvaluatedApplicationModel(application.FormA!));
        }
    }
}
