using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class Civilian : Character
    {
        private Random rng = new Random();
        private int aiVersion;
        private Hero hero;
        public Civilian(Texture2D texture, int fwidth, int fheight, Direction startDirection, int aiversion, Hero hero):base(texture, fwidth, fheight, startDirection)
        {
            this.aiVersion = aiversion;
            this.hero = hero;
        }

        public override void Move(GameTime gameTime, KeyboardState input)
        {
            if (aiVersion == 0)
            {
                Vector2 directionHero = hero.GetCenter() - this.position;
                directionHero.Normalize();
                this.position += directionHero * 2f;
                if (directionHero.X < 0) currDirection = Direction.Left;
                else currDirection = Direction.Right;
                if (directionHero.Y < 0) currDirection = Direction.Up;
                else currDirection = Direction.Down;
            }
            else if (aiVersion == 1)
            {
                Vector2 directionHero = hero.GetCenter() - this.position;
                float distanceHero = directionHero.Length();
                if (distanceHero > 500)
                {
                    directionHero.Normalize();
                    this.position += directionHero * 2f;
                }
            }
            else
            {
                //geen beweging, stilstaan op plaats
            }
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState inputKey = Keyboard.GetState();

            Move(gameTime, inputKey);

            UpdateAnimationFrame(gameTime); // animation update
        }
        private void UpdateAnimationFrame(GameTime gametime)
        {
            switch (currDirection) // animation frame update/correctie voor huidig direction
            {
                case Direction.Up:
                    animation.currFrame = animation.frames[12 + (animation.frames.IndexOf(animation.currFrame) % 4)];
                    break;
                case Direction.Down:
                    animation.currFrame = animation.frames[0 + (animation.frames.IndexOf(animation.currFrame) % 4)];
                    break;
                case Direction.Left:
                    animation.currFrame = animation.frames[4 + (animation.frames.IndexOf(animation.currFrame) % 4)];
                    break;
                case Direction.Right:
                    animation.currFrame = animation.frames[8 + (animation.frames.IndexOf(animation.currFrame) % 4)];
                    break;
                case Direction.Idle:
                    animation.currFrame = animation.frames[idleFrameIndex];
                    break;
            }
        }
    }
}
