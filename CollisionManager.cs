using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class CollisionManager
    {
        public bool CheckCollision(Civilian civ, Hero hero)
        {
            Rectangle rectCiv = new Rectangle( (int)civ.position.X, (int)civ.position.Y, civ.frameWidth, civ.frameHeight);
            Rectangle rectHero = new Rectangle( (int)hero.position.X, (int)hero.position.Y, hero.frameWidth, hero.frameHeight);

            return rectCiv.Intersects(rectHero);
        }

        public void HandleCollision(Civilian civilian, Hero hero)
        {
            if (CheckCollision(civilian, hero))
            {
                hero.LoseLive();
            }
        }
    }
}