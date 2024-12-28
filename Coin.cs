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
        public Vector2 Position { get; }
        private int width;
        private int height;
        public Coin(Texture2D texture, Vector2 position, int width, int height)
        {
            this.texture = texture;
            this.Position = position;
            this.width = width;
            this.height = height;
            this.Radius = width / 2f;
        }
        public float Radius
        {
            get;
        }

        public bool isCollected;//opzet voor eventuele alternatief pickup mechanisme ipv coin=null

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}