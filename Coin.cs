using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class Coin : IGameObject
    {
        private Texture2D texture;
        private Vector2 position;
        private int width;
        private int height;
        public Coin(Texture2D texture, Vector2 position, int width, int height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}