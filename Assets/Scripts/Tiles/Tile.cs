using OpenTK.Mathematics;

namespace Terraria.Tiles
{
    public abstract class Tile
    {
        public readonly static Vector2 UVOffset = new Vector2(16f, 16f);

        public abstract Vector2 UVStart { get; }
        public abstract TileType Type { get; }
    }
}
