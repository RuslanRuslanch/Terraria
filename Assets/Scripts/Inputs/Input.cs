using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Terraria.Inputs
{
    public class Input
    {
        public static MouseState Mouse;
        public static KeyboardState Keyboard;

        public static void SetInputDevices(MouseState mouse, KeyboardState keyboard)
        {
            Mouse = mouse; 
            Keyboard = keyboard;
        }
    }
}
