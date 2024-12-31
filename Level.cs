using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class Level : IGameObject
    {
        public static Random rng = new Random();
        public static int id = 0;
        public Hero hero;
        public List<Coin> coins = new List<Coin>();
        public Texture2D coinTexture;
        public Level(Texture2D ctexture, int civilianCount, int coinCount, Hero hero)
        {
            id += 1;
            this.hero = hero;
            coinTexture = ctexture;
            LevelSetup(coinCount);
        }
        public void LevelSetup(int count)
        {
            PlaceCoins(count);
        }
        private void PlaceCoins(int count)
        {
            for (int i = 0; i < count; i++)
            {
                coins.Add(new Coin(coinTexture, new Vector2(rng.Next(40, 1200), rng.Next(40, 900)), 64, 64));
            }
        }
        public bool AllCollected()
        {
            return coins.Count == 0;
        }

        public void Update(GameTime gametime)
        {
            for (int i = 0; i < coins.Count; i++)
            {
                if (coins[i] != null) coins[i].Update(gametime);

                if (coins[i] != null && Vector2.Distance(coins[i].GetCenter(), hero.GetCenter()) <= coins[i].Radius)
                {
                    coins.Remove(coins[i]);
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