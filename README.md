# DependencyInjection.ServiceFactory

An extension of `Microsoft.Extensions.DependencyInjection` providing service factory functionality for an application.

A service is used as the implementation factory for the instantiation of a particular service provided by dependency injection. This abstraction allows for the implementation code to be encapsulated into a service, and can be useful in situations where the creation of a service relies on other dependencies.

## Getting started

Add the service factory using the `IServiceFactory<T>` interface:

``` csharp
public class ExampleServiceFactory : IServiceFactory<IExampleService>
{
    // ...

    public IExampleService Create(IServiceProvider serviceProvider)
    {
        // ... create the service object

        return exampleService;
    }
}
```

*Note: the `serviceProvider` is not required to be used but is included to provide access to the service container, if needed.*

In *Startup.cs*, register the factory with the service collection:

```csharp
using App.Extensions.DependencyInjection.ServiceFactory;

public void ConfigureServices(IServiceCollection services)
{
    // ...
    
    services.AddFactory<IExampleService, ExampleServiceFactory>();
}
```

## Usage

When another service has a dependency on `IExampleService`, the `Create()` method on the service factory will be invoked and the returned instance will be used by the service container to inject the service.

The `Create()` method will be invoked depending on the lifetime defined for the service. For example, using the default *Singleton*, the method will only be invoked once and the returned instance will be used for all subsequent requests. See the documentation on [service lifetimes](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1#service-lifetimes) for more details.

## Example

Included in the repository is an example project demonstrating the creation of a service which is dependent on configuration. This allows for the type of the service object to be defined in an "appsettings.json" file.

The example project uses the [options pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1) to inject an options model into the service factory, which is then used in the `Create()` method to find the requested service type in the collection and return that implementation. Making it easy to change the injected service per environment, by just updating the type in the settings file.
