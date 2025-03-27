using Panthera2D;
using Panthera2D.Core;
using Panthera2D.Samples;
using Panthera2D.Samples.Drawables;

var factory = new ApplicationBuilder();
factory.ConfigureWindow(window =>
{
    window.Title = "Pillow Application";
    window.Size = new Vector2i(1000, 400);
});

factory.Create<PillowApplication>().Run();