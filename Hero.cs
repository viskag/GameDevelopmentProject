using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class Hero : IGameObject
    {
        public Hero(Texture2D texture)
        {
            herotexture = texture;
            animation = new Animation.Animation();
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(66, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(132, 0, 66, 66)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(198, 0, 66, 66)));
        }
        private Texture2D herotexture;
        Animation.Animation animation;

        public void Update(GameTime gametime)
        {
            animation.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(herotexture, new Vector2(10, 10), animation.currFrame.sourceRectangle, Color.White);
        }
    }
}
