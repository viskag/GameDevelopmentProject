using GameDevelopmentProject.Characters;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class GameState
    {
        private StartGamescreen startScreen;
        private EndGamescreen endGameScreen;
        private Hero hero;
        public bool IsRunning { get; set; }
        public bool IsGameOver { get; set; }
        public GameState(SpriteFont font, Hero hero)
        {
            startScreen = new StartGamescreen(font);
            endGameScreen = new EndGamescreen(font);
            IsRunning = false;
            IsGameOver = false;
            this.hero = hero;
        }
        public void StartGame()
        {
            IsRunning = true;
        }
        public void EndGame()
        {
            IsGameOver = true;
        }
        public void ResetGame()
        {
            IsRunning = false;
            IsGameOver = false;
        }
        public void Update()
        {
            if (!IsRunning && startScreen.Update()) IsRunning = true;
            else if (IsGameOver && endGameScreen.Update())
            {
                hero.lives = 3;
                hero.position = new Microsoft.Xna.Framework.Vector2(500, 500);
                if (Game1.currLevel > 0) Game1.currLevel -= 1;
                IsGameOver = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRunning) startScreen.Draw(spriteBatch);
            else if (IsGameOver) endGameScreen.Draw(spriteBatch);
        }
    }
}