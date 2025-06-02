using Terraria.Resources;

namespace Terraria.Graphics
{
    public struct Batch
    {
        public readonly int VAO;
        public readonly int IndexCount;
        public readonly Material Material;

        public Batch(int vAO, int indexCount, Material material)
        {
            VAO = vAO;
            IndexCount = indexCount;
            Material = material;
        }
    }
}
