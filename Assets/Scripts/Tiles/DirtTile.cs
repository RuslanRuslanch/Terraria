using OpenTK.Mathematics;

namespace Terraria.Tiles
{
    public class DirtTile : Tile
    {
        public override TileType Type => TileType.Dirt;
        public override Vector2 UVStart => new Vector2(32f, 0f);
    }
}
