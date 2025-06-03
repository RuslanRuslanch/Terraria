using OpenTK.Mathematics;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Tiles;

namespace Terraria.Worlds
{
    public partial class ChunkMeshBuilder
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
            var uvs = Tessellator.GetTileUVs(TileCache.Get(type).UVStart, Tile.UVOffset);

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

            return new TileMeshData(vertices, uvs, indecies);
        }
    }
}
