using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Screens
{
    internal abstract class GameScreen
    {
        protected string message;
        protected SpriteFont font;
        protected Color backgroundColor;
        protected Vector2 messagePosition;

        public GameScreen(SpriteFont spriteFont, string message, Color backgroundColor)
        {
            font = spriteFont;
            this.message = message;
            this.backgroundColor = backgroundColor;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 messageSize = font.MeasureString(message);
            messagePosition = new Vector2((spriteBatch.GraphicsDevice.Viewport.Width - messageSize.X)/2,
                (spriteBatch.GraphicsDevice.Viewport.Height - messageSize.Y) / 2);

            spriteBatch.DrawString(font, message, messagePosition, Color.Red);
        }

        public abstract bool Update();
    }
}