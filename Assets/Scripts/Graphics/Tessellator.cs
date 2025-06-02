using OpenTK.Mathematics;

namespace Terraria.Graphics
{
    public static class Tessellator
    {
        public static Vector2[] GetUVs(Vector2 uvStart, Vector2 uvOffset)
        {
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
