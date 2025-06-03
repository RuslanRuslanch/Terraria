namespace Terraria.Resources
{
    public struct LoadedTextureData
    {
        public readonly int ID;
        public readonly int Width;
        public readonly int Height;

        public LoadedTextureData(int id, int width, int height)
        {
            ID = id;
            Width = width;
            Height = height;
        }
    }
}
