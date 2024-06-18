using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Data;

namespace ResearchCruiseApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CruisesController(ResearchCruiseContext researchCruiseContext, IMapper mapper) : ControllerBase
    {
        [HttpPut("autoAdded")]
        public async Task<IActionResult> AutoAddCruises()
        {
            var applications = await researchCruiseContext.Applications.ToListAsync();
            var cruises = new List<Cruise>();
            
            applications
                .ForEach(application =>
                {
                    var newCruise = mapper.Map<Cruise>(application);
                });
            
            return NoContent();
        }
    }
}
