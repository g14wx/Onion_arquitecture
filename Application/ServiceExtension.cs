using System.Reflection;
using FluentValidation;
using MediatR;
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
     * what "this" is doing in the function paramaters like (this IServiceCollection services)?
     * https://stackoverflow.com/questions/3045242/this-in-function-parameter
     * Is part of the new feature introduce in .net 3 "Extensions Methods", where you have to define the class static and the method as well
     * this will attach the function to the object-type you are trying to target 
     */
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        // registing autoMapper to the service
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}