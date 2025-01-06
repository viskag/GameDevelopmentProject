using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Screens
{
    internal class EndGamescreen : GameScreen
    {
        public EndGamescreen(SpriteFont spriteFont) : base(spriteFont, "Game Over", Color.Black)
        {

        }

        public override bool Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
            {
                return true;
            }
            return false;
        }
    }
}