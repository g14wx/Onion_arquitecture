using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/*
 * This class will help us to group extensions of third parties services or that ones made by us
 * for example, if be want to register autoMapper then here is where it will be register in our service
 * 
 */
public static class ServiceExtension
{
    /**
     * Static method to register a service to our app
     */
    public static void AddApplicationLayer(IServiceCollection services)
    {
        // registing autoMapper to the service
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}