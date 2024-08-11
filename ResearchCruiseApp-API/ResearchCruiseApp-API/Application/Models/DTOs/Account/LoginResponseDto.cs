namespace ResearchCruiseApp_API.Application.Models.DTOs.Account;


internal class LoginResponseDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; } = null!;
}