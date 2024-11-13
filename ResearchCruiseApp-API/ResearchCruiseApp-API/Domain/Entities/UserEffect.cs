﻿using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class UserEffect : Entity, IEvaluated
{
    public Guid UserId { get; init; }

    public ResearchTaskEffect Effect { get; init; } = null!;

    public int Points { get; set; }
}