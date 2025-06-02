using OpenTK.Mathematics;
using Terraria.GameObjects;

namespace Terraria.Graphics
{
    public class GameObjectRect2D : Rect2D
    {
        public GameObjectRect2D(Transform transform, Vector2 min, Vector2 max) : base(transform, min, max)
        {
            Transform.Changed += LoadGlobalMax;
            Transform.Changed += LoadGlobalMin;
        }

        ~GameObjectRect2D()
        {
            Transform.Changed -= LoadGlobalMax;
            Transform.Changed -= LoadGlobalMin;
        }
    }
}
