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
    internal class WinGameScreen:GameScreen
    {
        public WinGameScreen(SpriteFont spriteFont):base(spriteFont, "You Win!", Color.Green)
        {
            messagePosition.X += 200;
            messagePosition.Y += 200;
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