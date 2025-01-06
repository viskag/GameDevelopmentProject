using GameDevelopmentProject.Characters;
using GameDevelopmentProject.Managers;
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
        public int coinCount;
        public int civilianCount;
        public Hero hero;
        public CoinManager coinManager;
        public CivilianManager civilianManager;
        public Level(Texture2D civTexture, Texture2D cointexture, int civilianCount, int coinCount, Hero hero)
        {
            id += 1;
            this.hero = hero;
            coinManager = new CoinManager(cointexture);
            this.coinCount = coinCount;
            civilianManager = new CivilianManager(civilianCount, civTexture, hero);

            LevelSetup();
        }
        public void LevelSetup()
        {
            coinManager.ScatterCoins(coinCount, Game1.screenHeight, Game1.screenWidth);
            civilianManager.ScatterCivilians(civilianCount, Game1.screenHeight, Game1.screenWidth);
        }
        public bool AllCollected()
        {
            return coinManager.AllCollected();
        }

        public void Update(GameTime gametime)
        {
            coinManager.Update(gametime, hero);
            coinCount = coinManager.coins.Count;
            civilianManager.Update(gametime, hero);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            coinManager.Draw(spriteBatch);
            civilianManager.Draw(spriteBatch);
        }
    }
}