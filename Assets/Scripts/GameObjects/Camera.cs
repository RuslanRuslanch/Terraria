using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Terraria.Graphics;
using Terraria.Inputs;
using Terraria.Worlds;

namespace Terraria.GameObjects
{
    public class Camera : GameObject
    {
        public const float ZNear = 0.01f;
        public const float ZFar = 100f;

        public const float MinZoom = 0.1f;
        public const float MaxZoom = 1f;

        public Matrix4 ProjectionMatrix { get; private set; } = Matrix4.Identity;
        public Matrix4 ViewMatrix { get; private set; } = Matrix4.Identity;

        public float ZoomFactor { get; private set; } = 1f;
        public CameraRect2D RenderRect { get; private set; }

        public Camera(World world) : base(world)
        {
            UpdateBounds();
            ReloadViewMatrix();
        }

        public override void OnSpawn()
        {
            GraphicsRenderer.Window.Resize += c => UpdateBounds();
            GraphicsRenderer.Window.Resize += c => ReloadProjectionMatrix();

            Transform.Changed += UpdateBounds;
            Transform.Changed += ReloadViewMatrix;
        }

        public bool InBounds(GameObjectRect2D rect)
        {
            return RenderRect.InBounds(rect);
        }

        public void SetZoom(float zoom)
        {
            ZoomFactor = Math.Clamp(zoom, MinZoom, MaxZoom);

            UpdateBounds();
            ReloadProjectionMatrix();
        }

        private void UpdateBounds()
        {
            var ascept = (float)GraphicsRenderer.Window.ClientSize.X / GraphicsRenderer.Window.ClientSize.Y;

            var min = new Vector2(-1.1f * ascept, -1.1f) / ZoomFactor;
            var max = new Vector2(1.1f * ascept, 1.1f) / ZoomFactor;

            RenderRect = new CameraRect2D(Transform, min, max);
        }

        public void Zoom(float zoom)
        {
            SetZoom(ZoomFactor + zoom);
        }

        public override void OnUpdate(float delta)
        {
            UpdateZoom(delta);
            UpdateMovement(delta);
        }

        private void UpdateZoom(float delta)
        {
            if (Input.Keyboard.IsKeyDown(Keys.PageUp))
            {
                Zoom(-delta);
            }
            else if (Input.Keyboard.IsKeyDown(Keys.PageDown))
            {
                Zoom(delta);
            }
        }

        private void UpdateMovement(float delta)
        {
            if (Input.Keyboard.IsAnyKeyDown == false)
            {
                return;
            }

            var velocity = Vector2.Zero;

            if (Input.Keyboard.IsKeyDown(Keys.A))
            {
                velocity -= Transform.Right;
            }
            if (Input.Keyboard.IsKeyDown(Keys.D))
            {
                velocity += Transform.Right;
            }
            if (Input.Keyboard.IsKeyDown(Keys.W))
            {
                velocity += Transform.Up;
            }
            if (Input.Keyboard.IsKeyDown(Keys.S))
            {
                velocity -= Transform.Up;
            }
            
            Transform.Move(velocity * delta * 5f);
        }

        private void ReloadProjectionMatrix()
        {
            var ascept = (float)GraphicsRenderer.Window.ClientSize.X / GraphicsRenderer.Window.ClientSize.Y;

            var width = (1f * ascept) / ZoomFactor;
            var height = 1f / ZoomFactor;

            var matrix = Matrix4.CreateOrthographicOffCenter(-width, width, -height, height, ZNear, ZFar);

            ProjectionMatrix = matrix;
        }

        private void ReloadViewMatrix()
        {
            var position = new Vector3(Transform.Position.X, Transform.Position.Y, 0f);
            var forward = new Vector3(0f, 0f, 1f);
            var up = new Vector3(Transform.Up.X, Transform.Up.Y, 0f);

            var matrix = Matrix4.LookAt(position, position + forward, up);

            ViewMatrix = matrix;
        }
    }
}
