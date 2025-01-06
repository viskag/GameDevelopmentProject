using GameDevelopmentProject.Characters;
using GameDevelopmentProject.Screens;
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
        private WinGameScreen winGameScreen;
        private Hero hero;
        public bool IsRunning { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsWon { get; set; }
        public GameState(SpriteFont font, Hero hero)
        {
            startScreen = new StartGamescreen(font);
            endGameScreen = new EndGamescreen(font);
            winGameScreen = new WinGameScreen(font);
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

        public void WinGame()
        {
            IsWon = true;
            IsRunning = true;
            IsGameOver = false;
        }
        public void Update()
        {
            if (!IsRunning && startScreen.Update()) IsRunning = true;
            else if (IsGameOver && endGameScreen.Update())
            {
                hero.lives = 3;
                hero.position = new Microsoft.Xna.Framework.Vector2(500, 500);
                if (GameController.currLevel > 0) GameController.currLevel -= 1;
                IsGameOver = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsWon) winGameScreen.Draw(spriteBatch);
            else if (!IsRunning) startScreen.Draw(spriteBatch);
            else if (IsGameOver) endGameScreen.Draw(spriteBatch);
        }
    }
}