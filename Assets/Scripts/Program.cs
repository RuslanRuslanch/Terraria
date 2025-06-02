using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Terraria.Graphics;

namespace Terraria
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var gameSettings = new GameWindowSettings();
            var nativeSettings = new NativeWindowSettings();

            nativeSettings.Title = "Terraria v2.0";
            nativeSettings.Profile = ContextProfile.Core;
            nativeSettings.ClientSize = new Vector2i(1280, 720);

            using (var window = new RenderWindow(gameSettings, nativeSettings))
            {
                window.Run();
            }
        }
    }
}
