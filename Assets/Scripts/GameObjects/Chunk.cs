using OpenTK.Mathematics;
using System.Diagnostics;
using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Tiles;

namespace Terraria.Worlds
{
    public class Chunk : GameObject
    {
        public const int Width = 16;
        public const int Height = 64;

        private readonly MeshRenderer _renderer;
        private readonly ChunkBuilder _builder;

        //public Tile[,] Tiles { get; private set; } = new Tile[Width, Height];
        public TileType[,] TileTypes { get; private set; } = new TileType[Width, Height];

        public Mesh Mesh { get; private set; }

        public Chunk(ChunkBuilder builder, World world) : base(world)
        {
            var rect = new GameObjectRect2D(Transform, Vector2.Zero, new Vector2(Width, Height));
            var material = ResourceManager.Get<Material>(ResourceNames.TilesMaterial);

            _renderer = new MeshRenderer(rect, material, this);
            _builder = builder;
        }

        public override void OnSpawn()
        {
            Generate();
        }


        public void Generate()
        {
            Console.WriteLine(Transform.Position);

            var tiles = _builder.TerrainGenerator.Generate(Transform.Position);
            var mesh = _builder.MeshBuilder.Build(tiles);

            SetTiles(tiles);
            SetMesh(mesh);
        }

        public void SetTiles(TileType[,] tiles)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    SetTile(new Vector2i(x, y), tiles[x, y]);
                }
            }
        }

        public void SetTile(Vector2i position, TileType tile)
        {
            Debug.Assert(IsValidPosition(position), "Tile position isn't valid!");

            //Tiles[position.X, position.Y] = tile;
            TileTypes[position.X, position.Y] = tile;
        }

        public void SetMesh(Mesh mesh)
        {
            Mesh = mesh;

            _renderer.SetMesh(mesh);
        }

        private bool IsValidPosition(Vector2i position)
        {
            if (position.X >= 0 && position.X < Width ||
                position.Y >= 0 && position.Y < Height)
            {
                return true;
            }

            return false;
        }
    }
}
