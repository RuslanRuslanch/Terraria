using OpenTK.Mathematics;
using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Tiles;

namespace Terraria.Worlds
{
    public class ChunkGenerator
    {
        private readonly FastNoiseLite _noise = new FastNoiseLite(228);

        public ChunkGenerator()
        {
            _noise.SetFrequency(0.1f);

            _noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2S);
            _noise.SetFractalType(FastNoiseLite.FractalType.FBm);
        }

        public TileType[,] Generate(Vector2 position)
        {
            var results = new TileType[World.Width, World.Height];

            for (int x = 0; x < World.Width; x++)
            {
                var height = _noise.GetNoise((x + position.X) * 0.2f, ((float)Math.Sin(x) + position.Y) * 0.2f) * 5f + 32;

                for (int y = 0; y < height; y++)
                {
                    if (height - y > 1)
                    {
                        results[x, y] = TileType.Grass;
                    }
                    else
                    {
                        results[x, y] = TileType.Stone;
                    }
                }
            }

            return results;
        }
    }
}
