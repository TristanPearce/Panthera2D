using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Panthera2D.Graphics;

namespace Panthera2D.Core;

public sealed class ApplicationBuilder
{
    private IServiceCollection serviceCollection;

    private List<Action<StartupInfo>> startupInfoConfigurators = [];

    public ApplicationBuilder()
    {
        serviceCollection = new ServiceCollection();
    }

    public void ConfigureServices(Action<IServiceCollection> serviceConfigurator)
    {
        serviceConfigurator(serviceCollection);
    }


    public void ConfigureStartupInfo(Action<StartupInfo> startupInfoConfigurator) => startupInfoConfigurators.Add(startupInfoConfigurator);


    public T Create<T>() where T : Application
    {
        var services = serviceCollection.BuildServiceProvider();
        using var scope = services.CreateScope();

        var startupInfo = new StartupInfo();
        startupInfoConfigurators.ForEach(configurator => configurator(startupInfo));

        var app = ActivatorUtilities.CreateInstance<T>(scope.ServiceProvider, startupInfo);
        
        return app;
    }
}
