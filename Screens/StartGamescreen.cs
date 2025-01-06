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
    internal class StartGamescreen : GameScreen
    {
        public StartGamescreen(SpriteFont spriteFont) : base(spriteFont, "Press Enter to Start...", Color.White)
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