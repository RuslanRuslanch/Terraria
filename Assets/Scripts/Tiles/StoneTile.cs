using OpenTK.Mathematics;

namespace Terraria.Tiles
{
    public class StoneTile : Tile
    {
        public override TileType Type => TileType.Stone;

        public override Vector2 UVStart => new Vector2(16f, 0f);
    }
}
