using System.Data.Common;
using OpenTK.Graphics.OpenGL;
using StbImageSharp;

namespace Terraria.Resources
{
    public class Texture : IResource
    {
        public readonly int ID;

        public readonly int Width;
        public readonly int Height;

        public Texture(string path)
        {
            var data = Create(path);

            ID = data.ID;
            Width = data.Width;
            Height = data.Height;
        }

        private LoadedTextureData Create(string path)
        {
            var id = GL.GenTexture();

            StbImage.stbi_set_flip_vertically_on_load(1);

            var image = ImageResult.FromStream(File.OpenRead(path), ColorComponents.RedGreenBlueAlpha);

            GL.BindTexture(TextureTarget.Texture2D, id);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);

            GL.BindTexture(TextureTarget.Texture2D, 0);

            return new LoadedTextureData(id, image.Width, image.Height);
        }
    }
}
