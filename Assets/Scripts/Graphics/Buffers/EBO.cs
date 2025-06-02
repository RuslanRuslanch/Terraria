using OpenTK.Graphics.OpenGL;

namespace Terraria.Graphics
{
    public class EBO
    {
        public const int ElementSize = sizeof(uint);

        public readonly int ID;

        public EBO(uint[] data)
        {
            ID = Create(data);
        }

        private int Create(uint[] data)
        {
            var id = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length * ElementSize, data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            return id;
        }

        public static void Delete(int id)
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.DeleteBuffer(id);
        }
    }
}
