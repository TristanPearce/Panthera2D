using Panthera2D.Graphics.Drawbles;

namespace Panthera2D.Graphics;

public interface IRenderer2D
{
    void BeginFrame();
    void EndFrame();

    void Render(Rectangle rectangle);
    void Render(Line line);
    void Render(Sprite sprite);
}