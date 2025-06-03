using OpenTK.Mathematics;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public static class Tessellator
    {
        public static Vector2[] GetTileUVs(Vector2 uvStart, Vector2 uvOffset)
        {
            var tilesTexture = ResourceManager.Get<Texture>(ResourceNames.TilesTexture);

            return GetUVs(uvStart, uvOffset, tilesTexture);
        }

        public static Vector2[] GetUVs(Vector2 uvStart, Vector2 uvOffset, Texture texture)
        {
            uvStart.X /= texture.Width;
            uvStart.Y /= texture.Height;

            uvOffset.X /= texture.Width;
            uvOffset.Y /= texture.Height;

            var uvs = new Vector2[]
            {
                new Vector2(uvStart.X, uvStart.Y),
                new Vector2(uvStart.X, uvStart.Y + uvOffset.Y),
                new Vector2(uvStart.X + uvOffset.X, uvStart.Y + uvOffset.Y),

                new Vector2(uvStart.X + uvOffset.X, uvStart.Y),
                new Vector2(uvStart.X + uvOffset.X, uvStart.Y + uvOffset.Y),
                new Vector2(uvStart.X, uvStart.Y),
            };

            return uvs;
        }
    }
}
