using OpenTK.Mathematics;

namespace Terraria.Resources
{
    public class Font : IResource
    {
        public readonly Vector2i SymbolSize;

        private readonly Dictionary<char, int> _buffers = new Dictionary<char, int>();

        public Font(Texture texture, Vector2i symbolSize)
        {
            SymbolSize = symbolSize;

            Create(texture);
        }

        private void Create(Texture texture)
        {
            
        }

        private int CreateSymbolBuffer(Vector2i uvStart)
        {
            return 0;
        }

        private int Get(char symbol)
        {
            return 0;
        }
    }
}
