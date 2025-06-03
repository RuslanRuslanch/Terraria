using OpenTK.Mathematics;
using Terraria.Graphics;

namespace Terraria.Resources
{
    public class Font : IResource
    {
        private readonly Dictionary<char, int> _buffers = new Dictionary<char, int>();

        private readonly char[] _symbols = new char[]
        {
            '1','2','3','4','5','6','7','8','9','0',
            'q','w','e','r','t','y','u','i','o','p',
            'a','s','d','f','g','h','j','k','l',
            'z','x','c','v','b','n','m',
            '!','@','#','$', '%', '^', '&', '*', '(', ')',
            '_', '+', '-', '=', '~', '`', '[', ']', '{', '}',
            '|', ';', ':', '\'', '"', ',', '.', '<', '>', '?'
        };

        public readonly Vector2i SymbolSize;
        public readonly Vector2 UVStart;

        public readonly Texture Texture;
        public readonly Shader Shader;

        public Font(Texture texture, Vector2i symbolSize)
        {
            SymbolSize = symbolSize;
            UVStart = new Vector2(symbolSize.X, 0f);

            Texture = texture;
            Shader = ResourceManager.Get<Shader>(ResourceNames.UIShader);

            Create();
        }

        private void Create()
        {
            for (int i = 0; i < _symbols.Length; i++)
            {
                var vao = CreateSymbolBuffer(i);

                AddSymbol(_symbols[i], vao);
            }
        }

        private void AddSymbol(char symbol, int vao)
        {
            if (_buffers.ContainsKey(symbol))
            {
                return;
            }

            _buffers.Add(symbol, vao);
        }

        private int CreateSymbolBuffer(int index)
        {
            var mesh = ResourceManager.Get<Mesh>(ResourceNames.SpriteMesh);
            var uvs = Tessellator.GetUVs(UVStart * index, SymbolSize, Texture);

            var vertexVbo = new VBO(Mesh.Parse(mesh.Vertices)).ID;
            var uvVBO = new VBO(Mesh.Parse(uvs)).ID;
            var ebo = new EBO(mesh.Indecies).ID;
            var vao = new VAO(uvVBO, vertexVbo, ebo, Shader).ID;

            VBO.Delete(vertexVbo);
            VBO.Delete(uvVBO);
            EBO.Delete(ebo);

            return vao;
        }

        public int Get(char symbol)
        {
            return _buffers[symbol];
        }
    }
}
