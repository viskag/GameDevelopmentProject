using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GameDevelopmentProject
{
    internal class Hero : Character
    {
        public Hero(Texture2D texture, int fwidth, int fheight, Direction startDirection):base(texture, fwidth, fheight, startDirection)
        {
            walkSpeed = new Vector2(3, 3);
            maxSpeed = new Vector2(9, 9);
            accSpeed = new Vector2(0.3f, 0.3f);
            currSpeed = new Vector2(0, 0);
        }

        public override void Move(GameTime gameTime, KeyboardState inputKey)
        {
            if (inputKey.IsKeyDown(Keys.Space) && currSpeed.X < maxSpeed.X && currSpeed.Y < maxSpeed.Y)
            {
                currSpeed *= 2; // accSpeed;
            }
            else if (currSpeed.X < walkSpeed.X && currSpeed.Y < walkSpeed.Y)
            {
                currSpeed += accSpeed;
            }

            if (inputKey.IsKeyDown(Keys.Up) && position.Y - currSpeed.Y >= 0) // checken wat de input key is
            {
                position.Y -= currSpeed.Y; // ga naar boven
                currSpeed.Y += accSpeed.Y;
                currDirection = Direction.Up;
                idleFrameIndex = 12; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Down) && position.Y + currSpeed.Y <= Game1.screenHeight - frameHeight)
            {
                position.Y += currSpeed.Y; // ga naar beneden
                currDirection = Direction.Down;
                idleFrameIndex = 0; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Left) && position.X - currSpeed.X >= 0)
            {
                position.X -= currSpeed.X; // ga naar links
                currDirection = Direction.Left;
                idleFrameIndex = 4; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Right) && position.X + currSpeed.X <= Game1.screenWidth - frameWidth)
            {
                position.X += currSpeed.X; // ga naar rechts
                currDirection = Direction.Right;
                idleFrameIndex = 8; // idle frame bijhouden
            }
            else currDirection = Direction.Idle;
            currSpeed = walkSpeed; // terug op walkspeed zetten
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