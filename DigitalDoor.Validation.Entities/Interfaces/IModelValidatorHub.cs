﻿namespace DigitalDoor.Validation.Entities.Interfaces;
public interface IModelValidatorHub<T>
{
    IEnumerable<ValidationError> Errors { get; }
    Task<bool> Validate(T model);
}
