using OpenTK.Mathematics;
using Terraria.Graphics;
using Terraria.Tiles;

namespace Terraria.Worlds
{
    public class ChunkMeshBuilder
    {
        public Mesh Build(TileType[,] tiles)
        {
            var mesh = new Mesh();

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

                    GenerateTile(position, tileType);
                }
            }

            return mesh;
        }

        private void GenerateTile(Vector2i position, TileType type)
        {

        }
    }
}
