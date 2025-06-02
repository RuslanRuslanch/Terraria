using Terraria.GameObjects;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public abstract class Renderer
    {
        public readonly Material Material;
        public readonly GameObject GameObject;

        public Renderer(Material material, GameObject gameObject)
        {
            Material = material;
            GameObject = gameObject;

            GameObject.World.AddRenderer(this);
        }

        ~Renderer()
        {
            GameObject.World.RemoveRenderer(this);
        }

        public abstract void PreRender();
        public abstract void Render();
    }
}
