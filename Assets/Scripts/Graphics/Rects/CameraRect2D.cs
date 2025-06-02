using OpenTK.Mathematics;
using Terraria.GameObjects;

namespace Terraria.Graphics
{
    public class CameraRect2D : Rect2D
    {
        public CameraRect2D(Transform transform, Vector2 min, Vector2 max) : base(transform, min, max)
        {
        }

        public bool InBounds(Rect2D other)
        {
            return Interects(other);
        }
    }
}
