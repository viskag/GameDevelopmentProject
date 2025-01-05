﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    public class Civilian : Character
    {
        private Random rng = new Random();
        private int aiVersion;
        public Hero hero;
        public Civilian(Texture2D texture, int fwidth, int fheight, Direction startDirection, int aiversion, Hero hero):base(texture, fwidth, fheight, startDirection)
        {
            this.aiVersion = aiversion;
            this.hero = hero;
        }

        public override void Move(GameTime gameTime, KeyboardState input)
        {
            Vector2 directionHero = hero.GetCenter() - this.position;
            float distanceHero = directionHero.Length();
            directionHero.Normalize();
            if (aiVersion == 0)
            {
                this.position += directionHero * 2f;
            }
            else if (aiVersion == 1)
            {
                if (distanceHero > 500)
                {
                    this.position += directionHero * 2f;
                }
            }
            else if (aiVersion == 2)
            {
                this.position += new Vector2(-0.5f, 0);
                //this.currDirection = Direction.Left;
            }
            else
            {
                //geen beweging, stilstaan op plaats
            }

            if (Math.Abs(directionHero.X) > Math.Abs(directionHero.Y) && aiVersion < 2)
            {
                if (directionHero.X < 0) currDirection = Direction.Left;
                else currDirection = Direction.Right;
            }
            else if (directionHero.Y < 0 && aiVersion < 2) currDirection = Direction.Up;
            else currDirection = Direction.Left;

            if (aiVersion >= 1 && distanceHero <= 500) currDirection = Direction.Idle;
            // maak een aparte methode updateDirection waar je gemakkelijk directionHero kan meegeven
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState inputKey = Keyboard.GetState();

            Move(gameTime, inputKey);

            UpdateAnimationFrame(gameTime);
        }
        private void UpdateAnimationFrame(GameTime gametime)
        {
            switch (currDirection)
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
