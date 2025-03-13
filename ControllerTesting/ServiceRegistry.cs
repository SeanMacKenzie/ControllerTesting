using ControllerTesting.Services;
using ControllerTesting.Services.Interfaces;

namespace ControllerTesting;

public static class ServiceRegistry
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Register your services here
        services.AddTransient<IBaseballService, BaseballService>();

        // You can also group related services
        services.RegisterDataServices();
        services.RegisterBusinessServices();

        services.AddHttpClient<IBaseballService, BaseballService>();
        return services;
    }

    private static IServiceCollection RegisterDataServices(this IServiceCollection services)
    {
        //services.AddScoped<IRepository1, Repository1>();
        //services.AddScoped<IRepository2, Repository2>();
        return services;
    }

    private static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        //services.AddScoped<IBusinessService1, BusinessService1>();
        //services.AddScoped<IBusinessService2, BusinessService2>();
        return services;
    }
}
