using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ResearchCruiseApp_API.Data;
using ResearchCruiseApp_API.Models;
using ResearchCruiseApp_API.Models.Users;
using ResearchCruiseApp_API.Tools;
using ResearchCruiseApp_API.Tools.Extensions;
using ResearchCruiseApp_API.Types;

namespace ResearchCruiseApp_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(
        UsersContext usersContext, UserManager<User> userManager)
        : ControllerBase
    {
        [Authorize(Roles = RoleName.Administrator)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await usersContext.Users.ToListAsync();
            var userModels = new List<UserModel>();

            foreach (var user in users)
            {
                userModels.Add(await UserModel.GetUserModel(user, userManager));
            }
            
            return Ok(userModels);
        }
        
        [Authorize(Roles = RoleName.Administrator)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            
            return Ok(await UserModel.GetUserModel(user, userManager));
        }
        
        [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.Shipowner}")]
        [HttpPost]
        public async Task<IActionResult> AddUser(
            [FromBody] RegisterModel registerModel, [FromServices] IServiceProvider serviceProvider)
        {
            if (registerModel.Role is null)
                return BadRequest("Nie wybrano roli dla nowego użytkownika");
            
            var emailAddressAttribute = new EmailAddressAttribute();
            if (string.IsNullOrEmpty(registerModel.Email) || !emailAddressAttribute.IsValid(registerModel.Email))
                return BadRequest("Adres e-mail jest niepoprawny");
            
            if (await userManager.FindByEmailAsync(registerModel.Email) != null)
                return Conflict("Użytkownik o tym adresie e-mail już istnieje");
            
            if (!await CanCurrentUserGiveRole(registerModel.Role))
                return Forbid();
            
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var rolesNames = await roleManager.Roles
                .Select(role => role.Name)
                .ToListAsync();
            if (!rolesNames.Contains(registerModel.Role))
                return BadRequest("Rola nie istnieje");
            
            var newUser = new User()
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Accepted = true
            };
            await userManager.CreateAsync(newUser, registerModel.Password);
            await userManager.AddToRoleAsync(newUser, registerModel.Role);

            var emailSender = serviceProvider.GetRequiredService<IEmailSender>();
            await emailSender.SendAccountConfirmationMessageAsync(
                newUser, registerModel.Email, registerModel.Role, serviceProvider);

            return Created();
        }

        [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.Shipowner}")]
        [HttpGet("unaccepted")]
        public async Task<IActionResult> GetAllUnacceptedUsers()
        {
            var users = await usersContext.Users
                .Where(user => user.EmailConfirmed && !user.Accepted)
                .ToListAsync();
            var userModels = new List<UserModel>();

            foreach (var user in users)
            {
                userModels.Add(await UserModel.GetUserModel(user, userManager));
            }

            return Ok(userModels);
        }

        [Authorize(Roles = $"{RoleName.Administrator}, {RoleName.Shipowner}")]
        [HttpPatch("unaccepted/{id}")]
        public async Task<IActionResult> AcceptUser(
            [FromRoute] string id, [FromServices] IServiceProvider serviceProvider)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            
            user.Accepted = true;
            await userManager.UpdateAsync(user);

         var emailSender = serviceProvider.GetRequiredService<IEmailSender>();
         await emailSender.SendAccountAcceptedMessageAsync(user);
            
            return NoContent();
        }

        [Authorize(Roles = RoleName.Administrator)]
        [HttpPatch("{id}/roles")]
        public async Task<IActionResult> ToggleUserRole(
            [FromRoute] string id,
            [FromBody] ToggleUserRoleModel toggleUserRoleModel,
            [FromServices] IServiceProvider serviceProvider)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user is null)
                return NotFound();
            
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var rolesNames = await roleManager.Roles
                .Select(role => role.Name!)
                .ToListAsync();

            if (rolesNames.Contains(toggleUserRoleModel.RoleName))
                await userManager.AddToRoleAsync(user, toggleUserRoleModel.RoleName);
            else
                return BadRequest(new { Message = "Role does not exist" });

            if (toggleUserRoleModel.AddRole)
                await userManager.AddToRoleAsync(user, toggleUserRoleModel.RoleName);
            else
                await userManager.RemoveFromRoleAsync(user, toggleUserRoleModel.RoleName);

            return NoContent();
        }


        private async Task<bool> CanCurrentUserGiveRole(string roleName)
        {
            var currentUserId = User.Claims
                .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            if (currentUserId is null)
                return false;
            
            var currentUser = await userManager.FindByIdAsync(currentUserId);
            if (currentUser is null)
                return false;
            
            var currentUserRoles = await userManager.GetRolesAsync(currentUser);
            
            if (currentUserRoles.Contains(RoleName.Administrator))
                return true;

            if (currentUserRoles.Contains(RoleName.Shipowner))
            {
                if (roleName is RoleName.Administrator or RoleName.Shipowner)
                    return false;
                return true;
            }
            
            return false;
        }
    }
}
