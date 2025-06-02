using OpenTK.Mathematics;

namespace Terraria.Tiles
{
    public abstract class Tile
    {
        public abstract Vector2 UVStart { get; }
        public abstract TileType Type { get; }
    }

    public class Grass : Tile
    {
        public override TileType Type => TileType.Grass;

        public override Vector2 UVStart => Vector2.Zero;
    }

    public class Stone : Tile
    {
        public override TileType Type => TileType.Stone;

        public override Vector2 UVStart => new Vector2(16f, 0f);
    }

    public enum TileType : byte
    {
        Air,
        Grass,
        Stone,
    }
}
