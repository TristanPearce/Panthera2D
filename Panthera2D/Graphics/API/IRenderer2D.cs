using Panthera2D.Graphics.Drawbles;

namespace Panthera2D.Graphics;

public interface IRenderer2D
{
    Viewport Viewport { get; }

    void BeginFrame();
    void EndFrame();

    void Clear(Color color);

    void Render(Rectangle rectangle);
    void Render(Line line);
    void Render(Sprite sprite);
}