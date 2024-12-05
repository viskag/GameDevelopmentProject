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
    internal class Hero : IGameObject
    {
        public Hero(Texture2D texture)
        {
            herotexture = texture;
            animation = new Animation.Animation();

            // beweging Down frames
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(66, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(132, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(198, 0, 66, 66)));

            // beweging Left frames
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 66, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(66, 66, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(132, 66, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(198, 66, 66, 66)));

            // beweging Right frames
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 132, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(66, 132, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(132, 132, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(198, 132, 66, 66)));

            // beweging Up frames
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 198, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(66, 198, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(132, 198, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(198, 198, 66, 66)));

            // startpositie (center) en startdirection (down)
            currDirection = "d";
            position = new Vector2(Game1.screenWidth/2-66/2, Game1.screenHeight/2-66/2);
        }

        private Texture2D herotexture;
        Animation.Animation animation;
        private Vector2 position;
        private string currDirection;
        private int idleFrameIndex;
        int speed = 2;

        public void Update(GameTime gametime)
        {animation.Update(gametime);//

            // ophalen bewegingsinput
            KeyboardState inputKey = Keyboard.GetState();

            // checken wat de input key is
            if (inputKey.IsKeyDown(Keys.Up))
            {
                position.Y -= speed; // ga naar boven
                currDirection = "u";
                idleFrameIndex = 12; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Down))
            {
                position.Y += speed; // ga naar beneden
                currDirection = "d";
                idleFrameIndex = 0; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Left))
            {
                position.X -= speed; // ga naar links
                currDirection = "l";
                idleFrameIndex = 4; // idle frame bijhouden
            }
            else if (inputKey.IsKeyDown(Keys.Right))
            {
                position.X += speed; // ga naar rechts
                currDirection = "r";
                idleFrameIndex = 8; // idle frame bijhouden
            }
            else
            {
                currDirection = "i";
            }
            

            // animation update
            UpdateAnimation(gametime);
        }
        private void UpdateAnimation(GameTime gametime)
        {
            // animation update op huidig direction
            if (currDirection == "u")
            {
                //animation.Update(gametime);
                animation.currFrame = animation.frames[12 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Up frames
            }
            else if (currDirection == "d")
            {
                //animation.Update(gametime);
                animation.currFrame = animation.frames[0 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Down frames
            }
            else if (currDirection == "l")
            {
                //animation.Update(gametime);
                animation.currFrame = animation.frames[4 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Left frames
            }
            else if (currDirection == "r")
            {
                //animation.Update(gametime);
                animation.currFrame = animation.frames[8 + (animation.frames.IndexOf(animation.currFrame) % 4)]; // Right frames

            }
            else
            {
                // bij idle/stilstaan moet laatste animatie worden ingenomen (de eerste frame daarvan)
                animation.currFrame = animation.frames[idleFrameIndex];
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(herotexture, position, animation.currFrame.sourceRectangle, Color.White);
        }
    }
}