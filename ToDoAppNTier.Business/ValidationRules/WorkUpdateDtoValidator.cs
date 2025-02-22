﻿using FluentValidation;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.ValidationRules;

public class WorkUpdateDtoValidator: AbstractValidator<WorkUpdateDto>
{
    public WorkUpdateDtoValidator()
    {
        RuleFor(x => x.Definition).NotEmpty();
        RuleFor(x => x.Id).NotEmpty();
    }
}