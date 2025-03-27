using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Panthera2D.Graphics;
using Panthera2D.Graphics.GLFW3;
using Panthera2D.Graphics.Platform.OpenGL;
using Panthera2D.Native;

namespace Panthera2D.Core;

public sealed class ApplicationBuilder
{
    private IServiceCollection serviceCollection;

    private List<Action<IWindow>> windowConfigurators = [];

    public ApplicationBuilder()
    {
        serviceCollection = new ServiceCollection();
    }

    public void ConfigureServices(Action<IServiceCollection> serviceConfigurator)
    {
        serviceConfigurator(serviceCollection);
    }

    public void ConfigureWindow(Action<IWindow> startupInfoConfigurator) => windowConfigurators.Add(startupInfoConfigurator);


    public T Create<T>() where T : Application
    {
        var services = serviceCollection.BuildServiceProvider();
        using var scope = services.CreateScope();

        var app = ActivatorUtilities.CreateInstance<T>(scope.ServiceProvider);
        windowConfigurators.ForEach((configurator) => configurator(app.Window));

        return app;
    }
}
