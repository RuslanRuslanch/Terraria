namespace Terraria.Resources
{
    public class Material : IResource
    {
        public readonly Texture Texture;
        public readonly Shader Shader;

        public Material(Texture texture, Shader shader)
        {
            Texture = texture;
            Shader = shader;
        }
    }
}
