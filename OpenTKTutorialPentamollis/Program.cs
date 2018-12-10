using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenTKTutorialPentamollis
{
    class Program
    {
        public static GameWindow window;
        public static Game game;
        public static ImmediateArtist immediateArtist;
        public static VBOArtist vboArtist;
        static void Main(string[] args)
        {
            window = new GameWindow(640, 360);
            game = new Game(window);
            immediateArtist = new ImmediateArtist();
            vboArtist = new VBOArtist();
            window.Run(1D / 60D);
        }
    }
}
