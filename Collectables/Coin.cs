﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.MapElements
{
    public class Coin : IGameObject
    {
        private Texture2D texture;
        public Vector2 Position { get; private set; }
        private int width;
        private int height;
        public Coin(Texture2D ctexture, Vector2 position, int width, int height)
        {
            texture = ctexture;
            Position = position;
            this.width = width;
            this.height = height;
            Radius = width / 2f;
        }
        public float Radius
        {
            get;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        public Vector2 GetCenter()
        {
            return new Vector2(Position.X + width / 2f, Position.Y + height / 2f);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}