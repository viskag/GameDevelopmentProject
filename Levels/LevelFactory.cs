using GameDevelopmentProject.Characters;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Levels
{
    public static class LevelFactory
    {
        public static Level CreateLevel(int civilianCount, int coinCount, Texture2D civTexture, Texture2D coinTexture, Hero hero)
        {
            return new Level(civTexture, coinTexture, civilianCount, coinCount, hero);
        }
    }
}