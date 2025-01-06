using GameDevelopmentProject.Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDevelopmentProject.Characters.Character;

namespace GameDevelopmentProject.Animation
{
    public class Animation
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
        public void UpdateAnimationFrame(GameTime gametime, Character.Direction currDirection, int idleFrameIndex)
        {
            switch (currDirection)
            {
                case Direction.Up:
                    currFrame = frames[12 + frames.IndexOf(currFrame) % 4];
                    break;
                case Direction.Down:
                    currFrame = frames[0 + frames.IndexOf(currFrame) % 4];
                    break;
                case Direction.Left:
                    currFrame = frames[4 + frames.IndexOf(currFrame) % 4];
                    break;
                case Direction.Right:
                    currFrame = frames[8 + frames.IndexOf(currFrame) % 4];
                    break;
                case Direction.Idle:
                    currFrame = frames[idleFrameIndex];
                    break;
            }
        }
    }
}