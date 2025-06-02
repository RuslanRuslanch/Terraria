using OpenTK.Graphics.OpenGL;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public class VAO
    {
        public const string VertexLocationName = "vPosition";
        public const string UVsLocationName = "vUVs";

        public readonly int ID;

        public VAO(int uvVBO, int vertexVBO, int ebo, Shader shader)
        {
            ID = Create(uvVBO, vertexVBO, ebo, shader);
        }

        private int Create(int uvVBO, int vertexVBO, int ebo, Shader shader)
        {
            var id = GL.GenVertexArray();

            var vertex = shader.GetLocation(VertexLocationName);
            var uvs = shader.GetLocation(UVsLocationName);

            GL.BindVertexArray(id);

            GL.EnableVertexAttribArray(uvs);
            GL.EnableVertexAttribArray(vertex);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
            GL.VertexAttribPointer(vertex, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, uvVBO);
            GL.VertexAttribPointer(uvs, 2, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DisableVertexAttribArray(vertex);
            GL.DisableVertexAttribArray(uvs);

            return id;
        }

        public static void Delete(int id)
        {
            GL.BindVertexArray(0);
            GL.DeleteVertexArray(id);
        }
    }
}
