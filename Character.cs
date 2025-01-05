using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDevelopmentProject.Hero;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevelopmentProject
{
    public abstract class Character : IGameObject
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Idle
        }
        protected Texture2D texture;
        protected Animation.Animation animation;
        public Vector2 position;
        public Direction currDirection;
        public int idleFrameIndex;
        public int frameWidth;
        public int frameHeight;
        public Vector2 currSpeed;
        public Vector2 walkSpeed;
        public Vector2 maxSpeed;
        public Vector2 accSpeed;

        public Character(Texture2D texture, int fwidth, int fheight, Direction startDirection)
        {
            this.texture = texture;
            this.frameWidth = fwidth;
            this.frameHeight = fheight;
            this.currDirection = startDirection;
            this.position = new Vector2(Game1.screenWidth / 2 - fwidth / 2, Game1.screenHeight / 2 - fheight / 2);
            this.animation = new Animation.Animation();
            MakeAnimation(animation, fwidth, fheight);
        }

        protected void MakeAnimation(Animation.Animation anim, int fwidth, int fheight)
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

        public abstract void Move(GameTime gameTime, KeyboardState input);
        public virtual void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.currFrame.sourceRectangle, Color.White);

        }
    }
}