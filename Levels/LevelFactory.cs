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
        public static Level CreateLevel(int difficulty, Texture2D civTexture, Texture2D coinTexture, Hero hero)
        {
            if (difficulty == 1) return new Level(civTexture, coinTexture, 1, 1, hero);
            else if (difficulty == 2) return new Level(civTexture, coinTexture, 2, 3, hero);
            else if (difficulty == 3) return new Level(civTexture, coinTexture, 3, 3, hero);
            else return new Level(civTexture, coinTexture, 0, 1, hero); // sandbox/testlevel
        }
    }
}