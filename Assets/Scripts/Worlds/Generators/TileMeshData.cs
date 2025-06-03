using OpenTK.Mathematics;

namespace Terraria.Worlds
{
    public partial class ChunkMeshBuilder
    {
        public struct TileMeshData
        {
            public readonly Vector3[] Vertices;
            public readonly Vector2[] UVs;
            public readonly uint[] Indecies;

            public TileMeshData(Vector3[] vertices, Vector2[] uvs, uint[] indecies)
            {
                Vertices = vertices;
                UVs = uvs;
                Indecies = indecies;
            }
        }
    }
}
