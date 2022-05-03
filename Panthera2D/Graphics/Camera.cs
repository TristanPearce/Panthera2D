using System.Numerics;

namespace Panthera2D.Graphics
{
    public class Camera
    {

        public Matrix4x4 Projection;
        public Matrix4x4 World;

        public Camera()
        {
            Projection = Matrix4x4.CreateOrthographic(2, 2, 0, 10);
            World = Matrix4x4.CreateTranslation(Vector3.Zero);
        }

        public Matrix4x4 GetWorldProjectionMatrix()
        {
            return World * Projection;
        }

    }
}
