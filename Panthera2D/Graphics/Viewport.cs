using System.Net.Http.Headers;
using System.Numerics;

namespace Panthera2D.Graphics
{
    public class Viewport
    {
        private bool isTranslationDirty;
        private bool isSizeDirty;

        private Matrix4x4 projection;
        private Matrix4x4 world;

        private Vector2 translation;
        private Vector2 size;

        public Viewport()
        {
            translation = Vector2.Zero;
            size = new Vector2(4, 4);
            isTranslationDirty = true;
            isSizeDirty = true;
        }

        public Matrix4x4 GetMatrix()
        {
            if (isTranslationDirty) UpdateWorld();
            if (isSizeDirty) UpdateProjection();

            return world * projection;
        }

        private void UpdateProjection()
        {
            projection = Matrix4x4.CreateOrthographic(size.X, size.Y, 0, int.MaxValue);
            isSizeDirty = false;
        }

        private void UpdateWorld()
        {
            world = Matrix4x4.CreateTranslation(translation.X, translation.Y, 0);
            isTranslationDirty = false;
        }

        public void SetTranslation(Vector2 newTranslation)
        {
            translation = newTranslation;
            isTranslationDirty = true;
        }

        public void Translate(Vector2 deltaTranslation)
        {
            translation += deltaTranslation;
            isTranslationDirty = true;
        }

        public void SetSize(Vector2 newSize)
        {
            size = newSize;
            isSizeDirty = true;
        }

        public void Resize(Vector2 deltaSize)
        {
            this.size += deltaSize;
            isSizeDirty = true;
        }
    }
}
