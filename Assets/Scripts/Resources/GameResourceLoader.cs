using OpenTK.Mathematics;
using Terraria.Graphics;
using Terraria.Tiles;

namespace Terraria.Resources
{
    public class GameResourceLoader
    {
        public void Load()
        {
            var texture = ResourceManager.GetAndLoadTexture(ResourceNames.TilesTexture, @"Assets\Textures\TilesAtlas.png");
            var mainShader = ResourceManager.GetAndLoadShader(ResourceNames.WorldSpaceShader, @"Assets\Shaders\MainVertexShader.vert", @"Assets\Shaders\MainFragmentShader.frag");
            var uiShader = ResourceManager.GetAndLoadShader(ResourceNames.UIShader, @"Assets\Shaders\UIVertexShader.vert", @"Assets\Shaders\MainFragmentShader.frag");

            ResourceManager.LoadMaterial(ResourceNames.TilesMaterial, new Material(texture, mainShader));

            LoadSpriteMesh();
            LoadTiles();
        }

        public void Unload()
        {
            // unload some resources
        }

        private void LoadSpriteMesh()
        {
            var vertices = new Vector3[]
            {
                Vector3.Zero,
                Vector3.UnitY,
                new Vector3(1f, 1f, 0f),
                Vector3.UnitX,
            };

            var indecies = new uint[]
            {
                0, 1, 2,
                2, 3, 0,
            };

            var uvs = Tessellator.GetTileUVs(Vector2.Zero, Vector2.One);

            var mesh = new Mesh(vertices, uvs, indecies);

            ResourceManager.LoadMesh(ResourceNames.SpriteMesh, mesh);
        }

        private void LoadTiles()
        {
            TileCache.Add(new GrassTile());
            TileCache.Add(new StoneTile());
            TileCache.Add(new DirtTile());
        }
    }
}
