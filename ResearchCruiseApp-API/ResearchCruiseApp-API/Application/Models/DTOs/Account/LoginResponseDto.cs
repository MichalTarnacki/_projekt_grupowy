﻿namespace ResearchCruiseApp_API.Application.Models.DTOs.Account;


public class LoginResponseDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime ExpiresIn { get; set; }
    public string RefreshToken { get; set; } = null!;
}