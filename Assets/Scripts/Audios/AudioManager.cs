namespace Terraria.Audios
{
    public static class AudioManager
    {
        public static AudioSource Create()
        {
            return new AudioSource();
        }

        public static void Delete(AudioSource source)
        {
            source = null;

            GC.Collect();
        }
    }
}
