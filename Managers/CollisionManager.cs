using GameDevelopmentProject.Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Managers
{
    public class CollisionManager
    {
        public bool CheckCollision(Civilian civ, Hero hero)
        {
            Rectangle rectCiv = new Rectangle((int)civ.position.X, (int)civ.position.Y, civ.frameWidth - 20, civ.frameHeight - 9);
            Rectangle rectHero = new Rectangle((int)hero.position.X, (int)hero.position.Y, hero.frameWidth - 20, hero.frameHeight - 9);

            return rectCiv.Intersects(rectHero);
        }

        public void HandleCollisions(Hero hero, Vector2 potentialPosition, List<SlowCivilian> civilians)
        {
            bool collisionOccurred = false;

            Vector2 adjustedPosition = potentialPosition;

            foreach (var civilian in civilians)
            {
                if (CheckCollision(civilian, hero))
                {
                    hero.LoseLive();
                    collisionOccurred = true;

                    Vector2 bounceVelocity = hero.currSpeed;

                    if (hero.currSpeed.X > 0)
                    {

                        bounceVelocity.X = -Math.Abs(bounceVelocity.X);
                        adjustedPosition.X = civilian.position.X - hero.frameWidth;
                    }
                    else if (hero.currSpeed.X < 0)
                    {
                        bounceVelocity.X = Math.Abs(bounceVelocity.X);
                        adjustedPosition.X = civilian.position.X + civilian.frameWidth;
                    }

                    if (hero.currSpeed.Y > 0)
                    {
                        bounceVelocity.Y = -Math.Abs(bounceVelocity.Y);
                        adjustedPosition.Y = civilian.position.Y - hero.frameHeight;
                    }
                    else if (hero.currSpeed.Y < 0)
                    {
                        bounceVelocity.Y = Math.Abs(bounceVelocity.Y);
                        adjustedPosition.Y = civilian.position.Y + civilian.frameHeight;
                    }

                    float positionBuffer = 1.0f; // tijdelijke fix: buffer toevoegen om gescufde collision verbeteren
                    adjustedPosition.X += positionBuffer;
                    adjustedPosition.Y += positionBuffer;

                    float smoother = 0.8f;

                    bounceVelocity *= smoother;

                    //if (Math.Abs(bounceVelocity.X) < 0.5f) //tijdelijkfix tegen 'scuffy' collision probleem: minimum bounce
                    //bounceVelocity.X = Math.Sign(bounceVelocity.X) * 0.5f;
                    //if (Math.Abs(bounceVelocity.Y) < 0.5f)
                    //bounceVelocity.Y = Math.Sign(bounceVelocity.Y) * 0.5f;

                    hero.currSpeed = bounceVelocity;

                    hero.position = adjustedPosition;

                    break;
                }
            }

            if (!collisionOccurred)
            {
                hero.position = potentialPosition;
            }
        }
    }
}