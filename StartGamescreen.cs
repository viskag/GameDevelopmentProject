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
    internal class StartGamescreen
    {
        private Color backgroundColor = Color.CornflowerBlue;
        private string message = "Press Enter to Start";
        private SpriteFont font;
        public StartGamescreen(SpriteFont spriteFont)
        {
            font = spriteFont;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Vector2 messageSize = font.MeasureString(message);
            // startmessage centraal zetten
            Vector2 messagePosition = new Vector2(
                (spriteBatch.GraphicsDevice.Viewport.Width - messageSize.X) / 2,
                (spriteBatch.GraphicsDevice.Viewport.Height - messageSize.Y) / 2
            );

            spriteBatch.DrawString(font, message, messagePosition, Color.Red);
        }

        public bool Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
            {
                return true; // start spel
            }
            return false; // blijf op menu
        }
    }
}
