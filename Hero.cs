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
    internal class Hero : IGameObject
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Idle
        }
        public Hero(Texture2D texture, int fwidth, int fheight, Direction startDirection)
        {
            herotexture = texture;
            animation = new Animation.Animation();

            frameHeight = fheight;
            frameWidth = fwidth;
            MakeAnimation(animation, fwidth, fheight);

            currDirection = startDirection; // startdirection (down) en startpositie (center)
            position = new Vector2(Game1.screenWidth/2-fwidth/2, Game1.screenHeight/2-fheight/2);
        }

        private void MakeAnimation(Animation.Animation anim, int fwidth, int fheight)
        {
            int rows = 4; // rijen zijn de 4 richtingen
            int columns = 4; // per richting 4 frames de kolomen

            for (int row = 0; row < rows; row++) // voor elke richting...
            {
                for (int col = 0; col < columns; col++) // ..elke frame toevoegen
                {
                    int x = col * fwidth; // x en y stellen de positie voor van waar de frame start
                    int y = row * fheight; // dus 1 frame is richting/frame maal dimensies ve frame

                    animation.AddFrame(new Animation.AnimationFrame(new Rectangle(x, y, fwidth, fheight)));
                }
            }
        }

        private Texture2D herotexture;
        private int idleFrameIndex;
        private Direction currDirection;
        private int frameWidth;
        private int frameHeight;
        Animation.Animation animation;
        private Vector2 position;
        private Vector2 currSpeed;
        private Vector2 walkSpeed = new Vector2(1,1);
        private Vector2 maxSpeed = new Vector2(4,4);
        private Vector2 acceleration = new Vector2(0.1f, 0.1f);

        public void Move(KeyboardState inputKey)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) // sprint en walk mechanic
            {
                currSpeed = maxSpeed;
            }
            if (inputKey.IsKeyDown(Keys.Up) && position.Y - currSpeed.Y >= 0) // checken wat de input key is
            {
                position.Y -= currSpeed.Y; // ga naar boven
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
        {animation.Update(gametime);//

            KeyboardState inputKey = Keyboard.GetState(); // ophalen bewegingsinput

            Move(inputKey); // move method uitvoeren afh vd keyboardstate

            UpdateAnimationFrame(gametime); // animation update
        }

        private void UpdateAnimationFrame(GameTime gametime)
        {
            // animation frame update/correctie voor huidig direction
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(herotexture, position, animation.currFrame.sourceRectangle, Color.White);
        }
    }
}