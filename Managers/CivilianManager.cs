using GameDevelopmentProject.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDevelopmentProject.Managers
{
    public class CivilianManager
    {
        public List<SlowCivilian> civilians;
        public static Random rng = new Random();
        private Texture2D texture;
        int civcount;
        public Hero hero;
        public CivilianManager(int civcount, Texture2D civTexture, Hero hero)
        {
            civilians = new List<SlowCivilian>();
            texture = civTexture;
            this.civcount = civcount;
            this.hero = hero;
        }

        public void AddCivilian(SlowCivilian civilian)
        {
            civilians.Add(civilian);
        }

        public void ScatterCivilians(int count, int screenHeight, int screenWidth)
        {
            for (int i = 0; i < civcount; i++)
            {
                Vector2 position = new Vector2(rng.Next(64, screenWidth - 64), rng.Next(64, screenHeight - 64));
                int randomAI = rng.Next(0, 3);

                SlowCivilian civ = new SlowCivilian(texture, 64, 64, Character.Direction.Down, randomAI, hero);

                civ.position = position;

                civilians.Add(civ);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Civilian civ in civilians)
            {
                civ.Draw(spriteBatch);
            }
        }
        public void Update(GameTime gametime, Hero hero)
        {
            foreach (Civilian civ in civilians)
            {
                civ.Update(gametime);
            }
        }
    }
}