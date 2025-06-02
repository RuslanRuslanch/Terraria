using OpenTK.Mathematics;
using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Resources;

namespace Terraria.Worlds
{
    public class Chunk : GameObject
    {
        public const int Width = 16;
        public const int Height = 64;

        private readonly MeshRenderer _renderer;
        private readonly ChunkGenerator _generator;

        public Chunk(ChunkGenerator generator, World world) : base(world)
        {
            var rect = new GameObjectRect2D(Transform, Vector2.Zero, new Vector2(Width, Height));
            var material = ResourceManager.Get<Material>(ResourceNames.TilesMaterial);

            _renderer = new MeshRenderer(rect, material, this);
            _generator = generator;
        }

        public override void OnSpawn()
        {
            var mesh = new Mesh();

            _renderer.SetMesh(mesh);
        }
    }
}
