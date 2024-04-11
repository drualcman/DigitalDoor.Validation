namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddDefaultModelValidatorServices(this IServiceCollection services)
    {
        services.TryAddScoped(typeof(IModelValidatorHub<>), typeof(ModelValidatorHub<>));
        return services;
    }

    public static IServiceCollection AddModelValidator<ModelType, ModelValidatorType>(this IServiceCollection services)
        where ModelValidatorType : class, IModelValidator<ModelType>
    {
        services.AddDefaultModelValidatorServices();
        services.AddScoped<IModelValidator<ModelType>, ModelValidatorType>();
        return services;
    }


}
