using OpenTK.Graphics.OpenGL;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public static class GraphicsRenderer
    {
        public static RenderWindow Window;

        private static Shader _shader;
        private static int _textureID;

        public static void SetWindow(RenderWindow window)
        {
            Window = window;
        }

        public static void Render(Batch batch)
        {
            BindMaterial(batch.Material);

            GL.BindVertexArray(batch.VAO);
            GL.DrawElements(PrimitiveType.Triangles, batch.IndexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public static void BindMaterial(Material material)
        {
            if (_shader != material.Shader)
            {
                _shader?.Disable();
                _shader = material.Shader;
                _shader.Enable();
            }
            if (_textureID != material.Texture.ID)
            {
                GL.BindTexture(TextureTarget.Texture2D, material.Texture.ID);
            }
        }
    }
}
