﻿namespace ResearchCruiseApp_API.Application.UseCases.Account.DTOs;


public class RegisterFormDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? Role { get; init; }
}