using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class EndGamescreen : GameScreen
    {
        public EndGamescreen(SpriteFont spriteFont):base(spriteFont, "Game Over! Press Enter voor Reset", Color.Black)
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