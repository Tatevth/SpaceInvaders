using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MusicController
    {
        public void PlayBackgroundMusic()
        {
            while (true)
            {
                 Console.Beep(440, 500);
                 Console.Beep(440, 500);
                 Console.Beep(440, 500);
                 Console.Beep(349, 350);
                 Console.Beep(523, 150);
                 Console.Beep(440, 500);
                 Console.Beep(349, 350);
                 Console.Beep(523, 150);
                 Console.Beep(440, 1000);
                 Console.Beep(659, 500);
                 Console.Beep(659, 500);
                 Console.Beep(659, 500);
                 Console.Beep(698, 350);
                 Console.Beep(523, 150);
                 Console.Beep(415, 500);
                 Console.Beep(349, 350);
                 Console.Beep(523, 150);
                 Console.Beep(440, 1000);
                Thread.Sleep(200);
            }
        }
    }
}
