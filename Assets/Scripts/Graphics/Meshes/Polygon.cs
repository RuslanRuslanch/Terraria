using OpenTK.Mathematics;

namespace Terraria.Graphics
{
    public struct Polygon
    {
        public readonly Vector3[] Vertices;
        public readonly Vector2[] TexCoords;
        public readonly Vector3 Normal;

        public Polygon(Vector3[] vertices, Vector2[] texCoords)
        {
            Vertices = vertices;
            TexCoords = texCoords;
            Normal = Vector3.UnitZ;
        }
    }
}
