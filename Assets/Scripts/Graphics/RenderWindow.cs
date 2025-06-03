using System.Net.Http.Headers;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Terraria.Inputs;
using Terraria.Resources;
using Terraria.Worlds;

namespace Terraria.Graphics
{
    public class RenderWindow : GameWindow
    {
        private readonly World _world = new World();
        private readonly GameResourceLoader _gameResourceLoader = new GameResourceLoader();

        private readonly TickSystem _tickSystem;

        public RenderWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            _tickSystem = new TickSystem(_world);

            //VSync = VSyncMode.On;
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthTest);

            Input.SetInputDevices(MouseState, KeyboardState);
            GraphicsRenderer.SetWindow(this);

            _gameResourceLoader.Load();
            _world.Load();
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            _world.Unload();
            _gameResourceLoader.Unload();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.CornflowerBlue);

            _world.Render();

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            var delta = (float)args.Time;

            _tickSystem.Calculate(delta);

            _world.Update(delta);
            _tickSystem.Tick();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}
