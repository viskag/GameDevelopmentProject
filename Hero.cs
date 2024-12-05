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
        public Hero(Texture2D texture, int fwidth, int fheight)
        {
            herotexture = texture;
            animation = new Animation.Animation();

            MakeAnimation(animation, fwidth, fheight);

            currDirection = "d"; // startdirection (down) en startpositie (center)
            position = new Vector2(Game1.screenWidth/2-66/2, Game1.screenHeight/2-66/2);
        }

        private void MakeAnimation(Animation.Animation anim, int fwidth, int fheight)
        {
            int rows = 4; // rijen zijn de 4 richtingen
            int columns = 4; // per richting 4 frames

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
        Animation.Animation animation;
        private string currDirection;
        private int idleFrameIndex;
        private Vector2 position;
        private Vector2 currSpeed;
        private Vector2 walkSpeed = new Vector2(1,1);
        private Vector2 maxSpeed = new Vector2(4,4);
        private Vector2 acceleration = new Vector2(0.1f, 0.1f);

        public void Update(GameTime gametime)
        {animation.Update(gametime);//

            KeyboardState inputKey = Keyboard.GetState(); // ophalen bewegingsinput

            
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) // sprint en walk mechanic
            {
                currSpeed = maxSpeed;
            }
            
            if (inputKey.IsKeyDown(Keys.Up)) // checken wat de input key is
            {
                position.Y -= currSpeed.Y; // ga naar boven
                currDirection = "u";
                idleFrameIndex = 12; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Down))
            {
                position.Y += currSpeed.Y; // ga naar beneden
                currDirection = "d";
                idleFrameIndex = 0; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Left))
            {
                position.X -= currSpeed.X; // ga naar links
                currDirection = "l";
                idleFrameIndex = 4; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Right))
            {
                position.X += currSpeed.X; // ga naar rechts
                currDirection = "r";
                idleFrameIndex = 8; // idle frame bijhouden
            }
            else currDirection = "i";

            currSpeed = walkSpeed; // terug op walkspeed zetten

            UpdateAnimation(gametime); // animation update
        }

        private void UpdateAnimation(GameTime gametime)
        {
            // animation update op huidig direction
            if (currDirection == "u")
            {//animation.Update(gametime);
                animation.currFrame = animation.frames[12 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Up frames
            }
            else if (currDirection == "d")
            {//animation.Update(gametime);
                animation.currFrame = animation.frames[0 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Down frames
            }
            else if (currDirection == "l")
            {//animation.Update(gametime);
                animation.currFrame = animation.frames[4 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Left frames
            }
            else if (currDirection == "r")
            {//animation.Update(gametime);
                animation.currFrame = animation.frames[8 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Right frames

            }
            // bij idle/stilstaan moet laatste animatie worden ingenomen (de eerste frame daarvan)
            else animation.currFrame = animation.frames[idleFrameIndex];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(herotexture, position, animation.currFrame.sourceRectangle, Color.White);
        }
    }
}