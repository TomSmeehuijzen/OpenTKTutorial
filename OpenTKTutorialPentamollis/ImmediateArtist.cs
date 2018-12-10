using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;

namespace OpenTKTutorialPentamollis
{
    class ImmediateArtist
    {
        public ImmediateArtist()
        {
            Program.game.Draw += OnDraw;
        }

        private void OnDraw(object sender, EventArgs e)
        {
            DrawSquare(30,30,100,150, Color.Yellow);
        }

        private void DrawSquare(float x, float y, float width, float height, Color color)
        {
            GL.Color3(color);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(x, y);
            GL.Vertex2(x + width, y);
            GL.Vertex2(x + width, y + height);
            GL.Vertex2(x, y + height);
            GL.End();
        }
    }
}
