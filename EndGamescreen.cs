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
    internal class EndGamescreen
    {
        private Color backgroundColor = Color.Black;
        private string message = "Game Over! Press Enter voor Reset";
        private SpriteFont font;

        public EndGamescreen(SpriteFont spriteFont)
        {
            font = spriteFont;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 messageSize = font.MeasureString(message);
            Vector2 messagePosition = new Vector2(
                (spriteBatch.GraphicsDevice.Viewport.Width - messageSize.X) / 2,
                (spriteBatch.GraphicsDevice.Viewport.Height - messageSize.Y) / 2
            );

            spriteBatch.DrawString(font, message, messagePosition, Color.White);
        }

        public bool Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
            {
                return true; // opnieuw beginnen
            }
            return false; // blijven op dit screen
        }
    }
}