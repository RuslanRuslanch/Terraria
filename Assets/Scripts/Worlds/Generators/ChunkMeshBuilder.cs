using OpenTK.Mathematics;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Tiles;

namespace Terraria.Worlds
{
    public class ChunkMeshBuilder
    {
        public Mesh Build(TileType[,] tiles)
        {
            var vertices = new List<Vector3>();
            var uvs = new List<Vector2>();
            var indecies = new List<uint>();

            for (int x = 0; x < Chunk.Width; x++)
            {
                for (int y = 0; y < Chunk.Height; y++)
                {
                    var tileType = tiles[x, y];

                    if (tileType == TileType.Air)
                    {
                        continue;
                    }

                    var position = new Vector2i(x, y);

                    var tileMesh = GenerateTile(position, tileType, (uint)vertices.Count);

                    vertices.AddRange(tileMesh.Vertices);
                    uvs.AddRange(tileMesh.UVs);
                    indecies.AddRange(tileMesh.Indecies);
                }
            }

            return new Mesh(vertices.ToArray(), uvs.ToArray(), indecies.ToArray());
        }

        private TileMeshData GenerateTile(Vector2i position, TileType type, uint vertexCount)
        {
            var mesh = ResourceManager.Get<Mesh>(ResourceNames.SpriteMesh);
            var uvs = Tessellator.GetTileUVs(TileCache.Get(type).UVStart, new Vector2(16f, 16f));

            var vertices = new Vector3[6];
            var indecies = new uint[6];

            for (int i = 0; i < mesh.Vertices.Length; i++)
            {
                vertices[i] = mesh.Vertices[i] + new Vector3(position.X, position.Y, 0f);
            }

            indecies[0] = vertexCount + 4 - 4;
            indecies[1] = vertexCount + 4 - 3;
            indecies[2] = vertexCount + 4 - 2;

            indecies[3] = vertexCount + 4 - 2;
            indecies[4] = vertexCount + 4 - 1;
            indecies[5] = vertexCount + 4 - 4;

            // 2, 3, 0,

            return new TileMeshData(vertices, uvs, indecies);
        }

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
