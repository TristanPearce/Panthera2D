using Panthera2D.Core;
using Panthera2D.Samples;
using Panthera2D.Samples.Drawables;

var factory = new ApplicationBuilder();
factory.ConfigureStartupInfo(info =>
{
    info.WindowTitle = "Panthera2D - Line Example";
    info.WindowWidth = 800;
    info.WindowHeight = 800;
});

factory.Create<PillowApplication>().Run();