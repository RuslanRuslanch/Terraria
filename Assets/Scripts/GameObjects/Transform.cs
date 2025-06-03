using OpenTK.Mathematics;

namespace Terraria.GameObjects
{
    public class Transform
    {
        public bool IsAllowUpdateMatrix { get; private set; } = true;

        public Matrix4 ModelMatrix { get; private set; } = Matrix4.Identity;

        public Vector2 Position { get; private set; } = Vector2.Zero;
        public float Rotation { get; private set; } = 0f;
        public Vector2 Scale { get; private set; } = Vector2.One;

        public Vector2 Right { get; private set; } = -Vector2.UnitX;
        public Vector2 Up { get; private set; } = Vector2.UnitY;

        public event Action Changed;

        public Transform()
        {
            ReloadModelMatrix();
        }

        public void Move(Vector2 velocity)
        {
            Position += velocity;

            ReloadModelMatrix();

            Changed?.Invoke();
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;

            ReloadModelMatrix();

            Changed?.Invoke();
        }

        public void SetRotation(float rotation)
        {
            Rotation = rotation;

            ReloadModelMatrix();

            Changed?.Invoke();
        }

        public void Rotate(float rotation)
        {
            Rotation += rotation;

            ReloadModelMatrix();

            Changed?.Invoke();
        }

        public void SetScale(Vector2 scale)
        {
            Scale = scale;

            ReloadModelMatrix();

            Changed?.Invoke();
        }

        public void AllowUpdateMatrix()
        {
            IsAllowUpdateMatrix = true; 
        }

        public void BlockUpdateMatrix()
        {
            IsAllowUpdateMatrix = false;
        }

        private void ReloadModelMatrix()
        {
            if (IsAllowUpdateMatrix == false)
            {
                return;
            }

            var anlge = MathHelper.DegreesToRadians(Rotation);

            var matrix =
                Matrix4.CreateScale(Scale.X, Scale.Y, 0f) *
                Matrix4.CreateRotationZ(anlge) *
                Matrix4.CreateTranslation(Position.X, Position.Y, Camera.ZNear);

            ModelMatrix = matrix;
        }
    }
}
