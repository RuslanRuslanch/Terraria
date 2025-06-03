using OpenTK.Mathematics;

namespace Terraria.Worlds
{
    public class ChunkBuilder
    {
        public readonly ChunkTerrainGenerator TerrainGenerator;
        public readonly ChunkMeshBuilder MeshBuilder;

        public ChunkBuilder(ChunkTerrainGenerator terrainGenerator, ChunkMeshBuilder meshBuilder)
        {
            TerrainGenerator = terrainGenerator;
            MeshBuilder = meshBuilder;
        }

        public Chunk Build(Vector2i position, World world)
        {
            var chunk = new Chunk(this, world);

            chunk.Transform.SetPosition(position);

            return chunk;
        }
    }
}
