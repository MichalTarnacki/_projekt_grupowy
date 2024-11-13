﻿namespace ResearchCruiseApp_API.Domain.Entities;

public class UserPublication : Entity
{
    public Guid UserId { get; init; }

    public Publication Publication { get; init; } = null!;
}