// <copyright file="TenantValidator.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

// Ignore Spelling: Validator
namespace AdminApi.Validators;

using AdminApi.Models;
using Common;
using FluentValidation;

public class TenantValidator : AbstractValidator<Tenant>
{
    private readonly IRepository _genericRepository;
    public TenantValidator(IRepository repository)
    {
        _genericRepository = repository;
        RuleFor(x => x.Name)
            .MaximumLength(20)
            .WithMessage("Cant have more than 20 characters in Name")
            .Must((name, _) => !_genericRepository.GetAll<Tenant>().Any(x => x.Name == name.Name))
            .WithMessage("Name must be unique");
    }
}