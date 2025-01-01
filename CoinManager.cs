using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class CoinManager
    {
        private List<Coin> coins;
        private static Random rng = new Random();
        public Texture2D coinTexture;

        public CoinManager(Texture2D coinTexture)
        {
            coins = new List<Coin>();
            this.coinTexture = coinTexture;
        }

        public void ScatterCoins(int coinCount, int screenWidth, int screenHeight)
        {
            for (int i = 0; i < coinCount; i++)
            {
                Vector2 position = new Vector2(rng.Next(64, screenWidth - 64), rng.Next(64, screenHeight - 64));

                Coin coin = new Coin(coinTexture, position, 64, 64);

                coins.Add(coin);
            }
        }

        public void AddCoin(Coin coin)
        {
            coins.Add(coin);
        }

        public bool AllCollected()
        {
            return coins.Count == 0;
        }

        public void Update(GameTime gametime, Hero hero)
        {
            for (int i = 0; i < coins.Count; i++)
            {
                Coin coin = coins[i];

                if (Vector2.Distance(coin.GetCenter(), hero.GetCenter()) <= coin.Radius)
                {
                    coins.RemoveAt(i); 
                    i--; 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Coin coin in coins)
            {
                coin.Draw(spriteBatch);
            }
        }
    }
}