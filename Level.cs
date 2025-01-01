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
        public CoinManager coinManager;
        public int coinCount;
        public Level(Texture2D ctexture, int civilianCount, int coinCount, Hero hero)
        {
            id += 1;
            this.hero = hero;
            coinManager = new CoinManager(ctexture);
            this.coinCount = coinCount;
            LevelSetup(coinCount);
        }
        public void LevelSetup(int count)
        {
            coinManager.ScatterCoins(coinCount, Game1.screenHeight, Game1.screenWidth);
        }
        public bool AllCollected()
        {
            return coinManager.AllCollected();
        }

        public void Update(GameTime gametime)
        {
            coinManager.Update(gametime, hero);
            coinCount = coinManager.coins.Count;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            coinManager.Draw(spriteBatch);
        }
    }
}