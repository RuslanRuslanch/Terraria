using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Resources;
using Terraria.Worlds;

namespace Terraria.Graphics
{
    public class TextRenderer : UIRenderer
    {
        private TextLetterRenderData[] _renderDatas = Array.Empty<TextLetterRenderData>(); 

        public readonly Font Font;

        public string Value { get; private set; }

        public TextRenderer(Font font, Material material, GameObject gameObject) : base(material, gameObject)
        {
            Font = font;
        }

        public void SetValue(string value)
        {
            Value = value;

            UpdateRenderData();
        }

        private void UpdateRenderData()
        {
            _renderDatas = new TextLetterRenderData[Value.Length];

            for (int i = 0; i < Value.Length; i++)
            {
                var vao = Font.Get(Value[i]);
                var transform = new Transform();
                var position = GameObject.Transform.Position + Font.SymbolSize * i;

                transform.SetPosition(position);

                var renderData = new TextLetterRenderData(vao, transform);

                _renderDatas[i] = renderData;
            }
        }

        public override void PreRender()
        {

        }

        public override void Render()
        {

        }
    }

    public struct TextLetterRenderData
    {
        public readonly int VAO;
        public readonly Transform Transform;

        public TextLetterRenderData(int vao, Transform transform)
        {
            VAO = vao;
            Transform = transform;
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
            var material = ResourceManager.Get<Material>(ResourceNames.FontMaterial);
            var font = ResourceManager.Get<Font>(ResourceNames.Font);

            _renderer = new TextRenderer(font, material, this);

            SetValue(value);
        }

        public void SetValue(string value)
        {
            Value = value;

            _renderer.SetValue(value);
        }
    }
}
