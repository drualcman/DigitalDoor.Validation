﻿namespace DigitalDoor.Validation.Entities.Abstractions;
public abstract class AbstractModelValidator<T>(
    IValidationService<T> validationService,
    ValidationConstraint constraint = ValidationConstraint.AlwaysValidate
    ) : IModelValidator<T>
{
    public ValidationConstraint Constraint => constraint;

    public IEnumerable<ValidationError> Errors { get; private set; }

    public async Task<bool> Validate(T model)
    {
        Errors = await validationService.Validate(model);
        return Errors == default;
    }

    protected IValidationRules<T, TProperty> AddRuleFor<TProperty>(
        Expression<Func<T, TProperty>> expression) =>
        validationService.AddRuleFor(expression);

    protected ICollectionValidationRules<T, TProperty> AddRuleForEach<TProperty>(
        Expression<Func<T, IEnumerable<TProperty>>> expression) =>
        validationService.AddRuleForEch(expression);

    public IValidationService<T> ValidatorService => validationService;
}
