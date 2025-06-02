using OpenTK.Graphics.OpenGL;

namespace Terraria.Graphics
{
    public class VBO
    {
        public const int ElementSize = sizeof(float);

        public readonly int ID;

        public VBO(float[] data)
        {
            ID = Create(data);
        }

        private int Create(float[] data)
        {
            var id = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * ElementSize, data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            return id;
        }

        public static void Delete(int id)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(id);
        }
    }
}
