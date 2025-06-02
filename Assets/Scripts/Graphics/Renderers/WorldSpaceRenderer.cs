using Terraria.GameObjects;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public abstract class WorldSpaceRenderer : Renderer
    {
        public readonly GameObjectRect2D Rect;

        public WorldSpaceRenderer(GameObjectRect2D rect, Material material, GameObject gameObject) : base(material, gameObject)
        {
            Rect = rect;
        }

        public abstract override void PreRender();
        public abstract override void Render();
    }
}
