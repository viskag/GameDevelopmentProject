using GameDevelopmentProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GameDevelopmentProject.Characters
{
    public class Hero : Character
    {
        public int lives = 3;
        private CollisionManager collisionManager = new CollisionManager();
        public List<SlowCivilian> civs = new List<SlowCivilian>();
        public Hero(Texture2D texture, int fwidth, int fheight, Direction startDirection) : base(texture, fwidth, fheight, startDirection)
        {
            maxSpeed = new Vector2(6, 6);
            accSpeed = new Vector2(0.1f, 0.1f);
            currSpeed = new Vector2(0, 0);
        }

        public override void Move(GameTime gameTime, KeyboardState inputKey)
        {
            if (!inputKey.IsKeyDown(Keys.Up) && !inputKey.IsKeyDown(Keys.Down) && !inputKey.IsKeyDown(Keys.Left) && !inputKey.IsKeyDown(Keys.Right))
            {
                if (currSpeed.X > 0)
                {
                    currSpeed.X -= accSpeed.X;
                    if (currSpeed.X < 0) currSpeed.X = 0;
                }
                else if (currSpeed.X < 0)
                {
                    currSpeed.X += accSpeed.X;
                    if (currSpeed.X > 0) currSpeed.X = 0;
                }

                if (currSpeed.Y > 0)
                {
                    currSpeed.Y -= accSpeed.Y;
                    if (currSpeed.Y < 0) currSpeed.Y = 0;
                }
                else if (currSpeed.Y < 0)
                {
                    currSpeed.Y += accSpeed.Y;
                    if (currSpeed.Y > 0) currSpeed.Y = 0;
                }
            }
            else
            {
                if (inputKey.IsKeyDown(Keys.Up))
                {
                    currSpeed.Y -= accSpeed.Y;
                }
                else if (inputKey.IsKeyDown(Keys.Down))
                {
                    currSpeed.Y += accSpeed.Y;
                }

                if (inputKey.IsKeyDown(Keys.Left))
                {
                    currSpeed.X -= accSpeed.X;
                }
                else if (inputKey.IsKeyDown(Keys.Right))
                {
                    currSpeed.X += accSpeed.X;
                }
            }
            if (currSpeed.X > maxSpeed.X) currSpeed.X = maxSpeed.X;
            if (currSpeed.Y > maxSpeed.Y) currSpeed.Y = maxSpeed.Y;
            if (currSpeed.X < -maxSpeed.X) currSpeed.X = -maxSpeed.X;
            if (currSpeed.Y < -maxSpeed.Y) currSpeed.Y = -maxSpeed.Y;

            Vector2 potentialPosition = position;
            potentialPosition.X += currSpeed.X;
            potentialPosition.Y += currSpeed.Y;
            collisionManager.HandleCollisions(this, potentialPosition, civs);

            position.X += currSpeed.X;
            position.Y += currSpeed.Y;

            if (position.X > Game1.screenWidth - frameWidth)
            {
                position.X = Game1.screenWidth - frameWidth;
                currSpeed.X = 0;
            }
            if (position.Y > Game1.screenHeight - frameHeight)
            {
                position.Y = Game1.screenHeight - frameHeight;
                currSpeed.Y = 0;
            }
            if (position.X < 0)
            {
                position.X = 0;
                currSpeed.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
                currSpeed.Y = 0;
            }

            if (inputKey.IsKeyDown(Keys.Up) && position.Y - currSpeed.Y >= 0)
            {
                //position.Y -= currSpeed.Y; // ga naar boven
                currDirection = Direction.Up;
                idleFrameIndex = 12; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Down) && position.Y + currSpeed.Y <= Game1.screenHeight - frameHeight)
            {
                //position.Y += currSpeed.Y; // ga naar beneden
                currDirection = Direction.Down;
                idleFrameIndex = 0; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Left) && position.X - currSpeed.X >= 0)
            {
                //position.X -= currSpeed.X; // ga naar links
                currDirection = Direction.Left;
                idleFrameIndex = 4; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Right) && position.X + currSpeed.X <= Game1.screenWidth - frameWidth)
            {
                //position.X += currSpeed.X; // ga naar rechts
                currDirection = Direction.Right;
                idleFrameIndex = 8; // idle frame bijhouden
            }
            else currDirection = Direction.Idle;
            //currSpeed = walkSpeed; // terug op walkspeed zetten
        }

        public void Update(GameTime gametime)
        {
            base.Update(gametime);

            KeyboardState inputKey = Keyboard.GetState(); // ophalen bewegingsinput

            Move(gametime, inputKey); // move method uitvoeren afh vd keyboardstate

            UpdateAnimationFrame(gametime); // animation update
        }

        private void UpdateAnimationFrame(GameTime gametime)
        {
            switch (currDirection) // animation frame update/correctie voor huidig direction
            {
                case Direction.Up:
                    animation.currFrame = animation.frames[12 + animation.frames.IndexOf(animation.currFrame) % 4];
                    break;
                case Direction.Down:
                    animation.currFrame = animation.frames[0 + animation.frames.IndexOf(animation.currFrame) % 4];
                    break;
                case Direction.Left:
                    animation.currFrame = animation.frames[4 + animation.frames.IndexOf(animation.currFrame) % 4];
                    break;
                case Direction.Right:
                    animation.currFrame = animation.frames[8 + animation.frames.IndexOf(animation.currFrame) % 4];
                    break;
                case Direction.Idle:
                    animation.currFrame = animation.frames[idleFrameIndex];
                    break;
            }
        }

        public Vector2 GetCenter() // centrum coordinaten van de held
        {
            return new Vector2(position.X + frameWidth / 2f, position.Y + frameHeight / 2f);
        }
        public void LoseLive()
        {
            if (lives > 0) lives--;
            else lives = 0;
        }
    }
}