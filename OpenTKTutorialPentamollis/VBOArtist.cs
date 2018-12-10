using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace OpenTKTutorialPentamollis
{
    class VBOArtist
    {
        private Vector2[] vertexBuffer;
        private int vertexBufferObjectName;

        public VBOArtist()
        {
            Program.game.Draw += OnDraw;
            PrepareBuffer();
        }

        private void PrepareBuffer()
        {
            SetVertexBuffer(0, 0, 0, 0);

            vertexBufferObjectName = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectName);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, (IntPtr)(Vector2.SizeInBytes * vertexBuffer.Length),
                vertexBuffer, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        private void SetVertexBuffer(float x, float y, float width, float height)
        {
            vertexBuffer = new Vector2[4]
            {
                new Vector2(x,y),
                new Vector2(x+width,y),
                new Vector2(x+width,y+height),
                new Vector2(x, y+height)
            };
        }

        private void OnDraw(object sender, EventArgs e)
        {
            DrawSquare(160f, 30f, 100f, 150f, Color.Red);
        }

        private void DrawSquare(float x, float y, float width, float height, Color color)
        {
            SetVertexBuffer(x, y, width, height);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectName);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, (IntPtr)(Vector2.SizeInBytes * vertexBuffer.Length),
                vertexBuffer, BufferUsageHint.StaticDraw);
            GL.VertexPointer(2, VertexPointerType.Float, Vector2.SizeInBytes, 0);
            GL.Color3(color);
            GL.DrawArrays(PrimitiveType.Quads, 0, vertexBuffer.Length);
        }
    }
}
