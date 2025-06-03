namespace Terraria.Tiles
{
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
