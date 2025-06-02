using OpenTK.Mathematics;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Worlds;

namespace Terraria.GameObjects
{
    public class Tile : GameObject
    {
        public readonly Mesh Mesh;

        public Tile(Mesh mesh, Material material, World world) : base(world)
        {
            var rect = new GameObjectRect2D(Transform, Vector2.Zero, Vector2.One);
            var renderer = new MeshRenderer(mesh, rect, material, this);
        }

        public override void OnUpdate(float delta)
        {
            //Transform.Rotate(delta * 30f);
        }
    }
}
