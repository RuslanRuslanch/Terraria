using OpenTK.Mathematics;
using Terraria.Graphics;

namespace Terraria.Resources
{
    public static class ResourceManager
    {
        private readonly static Dictionary<string, IResource> _resources = new Dictionary<string, IResource>();

        public static void LoadTexture(string name, string path)
        {
            var texture = new Texture(path);
                
            _resources.Add(name, texture);
        }

        public static void LoadShader(string name, string vertexPath, string fragmentPath)
        {
            var shader = new Shader(vertexPath, fragmentPath);

            _resources.Add(name, shader);
        }

        public static Font LoadFont(Texture texture, Vector2i symbolSize)
        {
            return new Font(texture, symbolSize);
        }

        public static T Get<T>(string name) where T : IResource
        {
            return (T)_resources[name];
        }

        public static Texture GetAndLoadTexture(string name, string path)
        {
            if (_resources.ContainsKey(name) == false)
            {
                LoadTexture(name, path);
            }

            return (Texture)_resources[name];
        }

        public static Shader GetAndLoadShader(string name, string vertexPath, string fragmentPath)
        {
            if (_resources.ContainsKey(name) == false)
            {
                LoadShader(name, vertexPath, fragmentPath);
            }

            return (Shader)_resources[name];
        }

        public static void LoadMesh(string name, Mesh mesh)
        {
            _resources.Add(name, mesh);
        }

        public static void LoadMaterial(string name, Material material)
        {
            _resources.Add(name, material);
        }

        public static void LoadMaterial(string name, Shader shader, Texture texture)
        {
            var material = new Material(texture, shader);

            _resources.Add(name, material);
        }
    }
}
