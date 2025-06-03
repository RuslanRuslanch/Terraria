using OpenTK.Mathematics;

namespace Terraria.Tiles
{
    public abstract class Tile
    {
        public abstract Vector2 UVStart { get; }
        public abstract TileType Type { get; }
    }

    public class GrassTile : Tile
    {
        public override TileType Type => TileType.Grass;

        public override Vector2 UVStart => Vector2.Zero; 
    }

    public class StoneTile : Tile
    {
        public override TileType Type => TileType.Stone;

        public override Vector2 UVStart => new Vector2(16f, 0f);
    }

    public class DirtTile : Tile
    {
        public override TileType Type => TileType.Dirt;
        public override Vector2 UVStart => new Vector2(32f, 0f);
    }

    public enum TileType : byte
    {
        Air,
        Grass,
        Stone,
        Dirt,
    }

    public static class TileCache
    {
        private readonly static Dictionary<TileType, Tile> _cache = new Dictionary<TileType, Tile>();

        public static Tile Get(TileType type)
        {
            return _cache[type];
        }

        public static void Add(Tile tile)
        {
            if (_cache.ContainsKey(tile.Type))
            {
                return;
            }

            _cache.Add(tile.Type, tile);
        }

        public static void RemoveAll()
        {
            _cache.Clear();
        }
    }
}
