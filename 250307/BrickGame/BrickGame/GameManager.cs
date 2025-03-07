using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class GameManager
    {
        Ball ball = null;
        Bar bar = null;

        public void Initialize()
        {
            // 공
            if (ball == null)
            {
                ball = new Ball();
                ball.Initialize();
            }

            // 바
            if (bar == null)
            {
                bar = new Bar();
                bar.Initialize();
            }

            ball.SetBar(bar);
        }

        public void Progress()
        {
            ball.Progress();
            bar.Progress(ref ball);
        }

        public void Render()
        {
            Console.Clear();
            ball.Render();
            bar.Render();
        }

        public void Release()
        {
            ball.Realese();
            bar.Release();
        }
    }
}
