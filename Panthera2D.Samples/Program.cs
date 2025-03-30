using Panthera2D;
using Panthera2D.Core;
using Panthera2D.Samples;

using System.Threading.Tasks;

var factory = new ApplicationBuilder();
factory.ConfigureWindow(window =>
{
    window.Title = "Pillow Application";
    window.Size = new Vector2i(800, 600);
});

var app1 = Task.Run(() => { using var app = factory.Create<PillowApplication>(); app.Run(); });

await Task.WhenAll(app1);