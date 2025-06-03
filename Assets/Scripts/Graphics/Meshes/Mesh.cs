using OpenTK.Mathematics;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public class Mesh : IResource
    {
        public Vector3[] Vertices { get; private set; } = Array.Empty<Vector3>();
        public Vector2[] UVs { get; private set; } = Array.Empty<Vector2>();
        public uint[] Indecies { get; private set; } = Array.Empty<uint>();

        public int IndexCount { get; private set; } = 0;

        public Mesh()
        {

        }

        public Mesh(Vector3[] vertices, Vector2[] uvs, uint[] indecies)
        {
            SetVertices(vertices);
            SetUVs(uvs);
            SetIndecies(indecies);
        }

        public void SetUVs(Vector2[] uvs)
        {
            UVs = uvs;
        }

        public void SetIndecies(uint[] indecies)
        {
            Indecies = indecies;

            IndexCount = indecies.Length;
        }

        public void SetVertices(Vector3[] vertices)
        {
            Vertices = vertices;
        }

        public static float[] Parse(Vector2[] uvs)
        {
            var output = new List<float>();

            foreach (var uv in uvs)
            {
                output.Add(uv.X);
                output.Add(uv.Y);
            }

            return output.ToArray();
        }

        public static float[] Parse(Vector3[] vertices)
        {
            var output = new List<float>();

            foreach (var vertex in vertices)
            {
                output.Add(vertex.X);
                output.Add(vertex.Y);
                output.Add(vertex.Z);
            }

            return output.ToArray();
        }
    }
}
