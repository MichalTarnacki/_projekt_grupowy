using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResearchCruiseApp_API.Data;
using ResearchCruiseApp_API.Models;
using ResearchCruiseApp_API.Types;

namespace ResearchCruiseApp_API.Controllers
{
    [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.CruiseManager}")]
    [Route("[controller]")]
    [ApiController]
    public class FormsController(
        ResearchCruiseContext researchCruiseContext) 
        : ControllerBase
    //1 argument contextowy - jest to zbiór tabel bazodanowych
    
    //stworzyć model (obiekt transferu danych) dla formularza A
    //w katalogu Models stworzyć schemat json DTO
    
    {
        //metoda zwracania formualrza po id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormById([FromRoute] string id)
        {
            await researchCruiseContext.FormsA.FindAsync(id);
            
            

            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            return Ok();
        }
        
        //metody do przyjmowania formularzy (POST) 
        [HttpPost]
        public async Task<IActionResult> AddForm([FromBody] FormsModel form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //var form_1 = Mapper.Map<FormsModel>(form);
            //researchCruiseContext.Forms.Add(form);
            //await formsContext.SaveChangeAsync();
            Console.WriteLine("zapisywanie rozpoczete");
            
            var form1 = new FormA()
            {
                Students = form.Students
            };
            Console.WriteLine(form1.ToString());
            researchCruiseContext.FormsA.Add(form1);
            await researchCruiseContext.SaveChangesAsync();

            return Ok();
        }
        
        //metoda zwracania formualrzy listy
    }
}
