using OpenTK.Mathematics;
using Terraria.GameObjects;

namespace Terraria.Graphics
{
    public class Rect2D
    {
        public readonly Transform Transform;

        public readonly Vector2 Min;
        public readonly Vector2 Max;
        public readonly Vector2 Center;

        public Vector2 MinGlobal { get; private set; }
        public Vector2 MaxGlobal { get; private set; }

        public Rect2D(Transform transform, Vector2 min, Vector2 max)
        {
            Transform = transform;
            Min = min;
            Max = max;
            Center = (Min + Max) / 2f;

            LoadGlobalMax();
            LoadGlobalMin();
        }

        public void LoadGlobalMin()
        {
            MinGlobal = Transform.Position + Min * Transform.Scale;
        }

        public void LoadGlobalMax()
        {
            MaxGlobal = Transform.Position + Max * Transform.Scale;
        }

        public bool Interects(Rect2D other)
        {
            var aMin = MinGlobal;
            var aMax = MaxGlobal;

            var bMin = other.MinGlobal;
            var bMax = other.MaxGlobal;

            if (aMax.X < bMin.X || aMin.X > bMax.X ||
                aMax.Y < bMin.Y || aMin.Y > bMax.Y)
            {
                return false;
            }

            return true;
        }
    }
}
