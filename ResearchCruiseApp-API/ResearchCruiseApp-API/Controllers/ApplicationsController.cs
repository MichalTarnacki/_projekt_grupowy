using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Data;
using ResearchCruiseApp_API.Models;
using ResearchCruiseApp_API.Tools;
using ResearchCruiseApp_API.Types;
using ResearchCruiseApp_API.Controllers;
using Microsoft.EntityFrameworkCore.Query;

namespace ResearchCruiseApp_API.Controllers
{
    [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.Shipowner}")]
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController(
        ResearchCruiseContext researchCruiseContext,
        IMapper mapper,
        IApplicationEvaluator applicationEvaluator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await GetApplicationsQuery()
                .ToListAsync();
            
            var applicationModels = applications
                .Select(mapper.Map<ApplicationModel>)
                .ToList();

            return Ok(applicationModels);
        }

        private IIncludableQueryable<Application, FormC?> GetApplicationsQuery()
        {
            return researchCruiseContext.Applications
                .Include(application => application.FormA)
                .Include(application => application.FormB)
                .Include(application => application.FormC);
        }
        
        /*public GetAllCruiseEffectsFromDb()
        {
            return researchCruiseContext.CruiseEffects
                .Include(application => application.FormA)
                .Include(application => application.FormB)
                .Include(application => application.FormC);
        }*/

        [HttpGet("{applicationId:guid}/points")]
        public async Task<IActionResult> CalculatePoints([FromRoute] Guid applicationId)
        {
            var application = await GetApplicationsQuery()
                .Include(application =>
                    application.FormA != null ? application.FormA.Contracts : null)
                .Include(application =>
                    application.FormA != null ? application.FormA.Publications : null)
                .Include(application =>
                    application.FormA != null ? application.FormA.Works : null)
                .Include(application =>
                    application.FormA != null ? application.FormA.GuestTeams : null)
                .Include(application =>
                    application.FormA != null ? application.FormA.ResearchTasks : null)
                .Include(application =>
                    application.FormA != null ? application.FormA.UGTeams : null)
                .Include(application =>
                    application.FormA != null ? application.FormA.SPUBTasks : null)
                .FirstOrDefaultAsync(application => application.Id == applicationId);

            if (application == null)
                return NotFound();
            if (application.FormA == null)
                return BadRequest();

            var mapper = MapperConfig.InitializeAutomapper();

            var formAModel = mapper.Map<FormAModel>(application.FormA);
            var evaluatedApplicationModel = applicationEvaluator.EvaluateApplication(formAModel, []);
            
            return Ok(evaluatedApplicationModel);
        }
    }
}
