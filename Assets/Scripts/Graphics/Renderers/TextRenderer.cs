using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Worlds;

namespace Terraria.Graphics
{
    partial class TextRenderer : UIRenderer
    {
        public TextRenderer(Material material, GameObject gameObject) : base(material, gameObject)
        {
        }

        public override void PreRender()
        {

        }

        public override void Render()
        {

        }
    }
}

namespace Terraria.GameObjects
{
    public class Text : GameObject
    {
        public string Value { get; private set; }

        private readonly TextRenderer _renderer;

        public Text(string value, World world) : base(world)
        {
            _renderer = new TextRenderer(null, this);

            SetValue(value);
        }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}
