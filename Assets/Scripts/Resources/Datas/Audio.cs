using OpenTK.Audio.OpenAL;

namespace Terraria.Resources
{
    public class Audio : IResource
    {
        public readonly int ID;

        private int Create()
        {
            var id = AL.GenBuffer();


            return id;
        }
    }
}
