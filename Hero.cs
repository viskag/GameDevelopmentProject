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
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(66, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(132, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(198, 0, 66, 66)));
        }
        private Texture2D herotexture;
        Animation.Animation animation;
        private Vector2 position;

        public void Update(GameTime gametime)
        {
            animation.Update(gametime);

            // Get the current state of the keyboard
            KeyboardState state = Keyboard.GetState();

            // Move the hero based on arrow key input
            if (state.IsKeyDown(Keys.Up))
            {
                position.Y -= 2; // Move up
            }
            if (state.IsKeyDown(Keys.Down))
            {
                position.Y += 2; // Move down
            }
            if (state.IsKeyDown(Keys.Left))
            {
                position.X -= 2; // Move left
            }
            if (state.IsKeyDown(Keys.Right))
            {
                position.X += 2; // Move right
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(herotexture, position, animation.currFrame.sourceRectangle, Color.White);
        }
    }
}