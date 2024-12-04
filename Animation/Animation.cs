using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Animation
{
    internal class Animation
    {
        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public AnimationFrame currFrame { get; set; }
        public List<AnimationFrame> frames;
        private int counter;
        private double frameMovement = 0;
        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            currFrame = frames[0];
        }
        public void Update(GameTime gametime)
        {
            currFrame = frames[counter];
            frameMovement += currFrame.sourceRectangle.Width * gametime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= currFrame.sourceRectangle.Width / 9)
            {
                counter++;
                frameMovement = 0;
            }
            if (counter >= frames.Count) { counter = 0; }
        }
    }
}
