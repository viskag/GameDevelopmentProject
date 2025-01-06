﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDevelopmentProject.Characters.Character;

namespace GameDevelopmentProject.Characters
{
    public class NormalCivilian : Civilian
    {
        public NormalCivilian(Texture2D texture, int fwidth, int fheight, Direction startDirection, int aiversion, Hero hero)
            : base(texture, fwidth, fheight, startDirection, aiversion, hero)
        {
            walkSpeed = 3f;
        }
    }
}
