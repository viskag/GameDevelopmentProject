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
    internal class Level
    {
        public static Random rng = new Random();
        public static int id = 0;
        public Hero hero;
        public List<Coin> coins = new List<Coin>();
        public Level(int civilianCount, int coinCount, Hero hero)
        {
            id += 1;
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
                //coins.Add(new Coin(null, new Vector2(rng.Next(10, 1200)), 64, 64));
            }
        }
        public bool AllCollected()
        {
            return coins.Count == 0;
        }
    }
}