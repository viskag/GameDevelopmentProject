using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Characters
{
    public abstract class Civilian : Character
    {
        private Random rng = new Random();
        protected int aiVersion;
        public Hero hero;
        public float walkSpeed;
        public Civilian(Texture2D texture, int fwidth, int fheight, Direction startDirection, int aiversion, Hero hero) : base(texture, fwidth, fheight, startDirection)
        {
            aiVersion = aiversion;
            this.hero = hero;
        }

        public override void Move(GameTime gameTime, KeyboardState input)
        {
            Vector2 directionHero = hero.GetCenter() - position;
            float distanceHero = directionHero.Length();
            directionHero.Normalize();
            if (aiVersion == 0) // volg en ga naar hero
            {
                position += directionHero * walkSpeed;
            }
            else if (aiVersion == 1) // volg maar houd afstand van hero
            {
                if (distanceHero > 500)
                {
                    position += directionHero * walkSpeed;
                }
            }
            else if (aiVersion == 2) // patrol: op en neer bewegen binnen de mapgrenzen
            {
                if (currDirection == Direction.Up)
                {
                    if (position.Y > 0)
                    {
                        position += new Vector2(0, -walkSpeed);
                    }
                    else
                    {
                        currDirection = Direction.Down;
                    }
                }
                else if (currDirection == Direction.Down)
                {
                    if (position.Y < Game1.screenHeight - 64)
                    {
                        position += new Vector2(0, walkSpeed);
                    }
                    else
                    {
                        currDirection = Direction.Up;
                    }
                }
            }
            else
            {
                //geen beweging, stilstaan op plaats, zogezegd '4de AI type'
            }

            if (Math.Abs(directionHero.X) > Math.Abs(directionHero.Y) && aiVersion < 2)
            {
                if (directionHero.X < 0) currDirection = Direction.Left;
                else currDirection = Direction.Right;
            }
            else if (directionHero.Y < 0 && aiVersion < 2) currDirection = Direction.Up;
            else if (aiVersion != 2) currDirection = Direction.Down;

            if (aiVersion == 1 && distanceHero <= 500 ) currDirection = Direction.Idle;
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState inputKey = Keyboard.GetState();

            Move(gameTime, inputKey);

            UpdateAnimationFrame(gameTime);
        }
        //private void UpdateAnimationFrame(GameTime gametime)
        //{
        //    switch (currDirection)
        //    {
        //        case Direction.Up:
        //            animation.currFrame = animation.frames[12 + animation.frames.IndexOf(animation.currFrame) % 4];
        //            break;
        //        case Direction.Down:
        //            animation.currFrame = animation.frames[0 + animation.frames.IndexOf(animation.currFrame) % 4];
        //            break;
        //        case Direction.Left:
        //            animation.currFrame = animation.frames[4 + animation.frames.IndexOf(animation.currFrame) % 4];
        //            break;
        //        case Direction.Right:
        //            animation.currFrame = animation.frames[8 + animation.frames.IndexOf(animation.currFrame) % 4];
        //            break;
        //        case Direction.Idle:
        //            animation.currFrame = animation.frames[idleFrameIndex];
        //            break;
        //    }
        //}
    }
}