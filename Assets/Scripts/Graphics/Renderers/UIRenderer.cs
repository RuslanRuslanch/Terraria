using Terraria.GameObjects;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public abstract class UIRenderer : Renderer
    {
        public UIRenderer(Material material, GameObject gameObject) : base(material, gameObject)
        {
        }

        public abstract override void PreRender();
        public abstract override void Render();
    }
}
