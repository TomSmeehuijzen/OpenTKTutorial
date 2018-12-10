using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTutorialPentamollis
{
    internal class Game
    {
        private GameWindow window;

        public Game(GameWindow window)
        {
            this.window = window;
            window.RenderFrame += OnRenderFrame;
            window.Resize += OnWindowResize;
            GL.ClearColor(System.Drawing.Color.LightBlue);
        }

        private void OnRenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            InvokeDraw();
            GL.Flush();
            window.SwapBuffers();
        }

        private void OnWindowResize(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0d, window.Width, window.Height, 0d, -1d, 1d);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void InvokeDraw()
        {
            Draw?.Invoke(this, System.EventArgs.Empty);
        }
        public event System.EventHandler Draw;
    }
}