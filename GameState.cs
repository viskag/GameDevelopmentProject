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
        public bool IsRunning { get; set; }
        public bool IsGameOver { get; set; }
        public GameState(SpriteFont font)
        {
            startScreen = new StartGamescreen(font);
            endGameScreen = new EndGamescreen(font);
            IsRunning = false;
            IsGameOver = false;
        }
        public void StartGame()
        {
            IsRunning = true;
            IsGameOver = false;
        }
        public void EndGame()
        {
            IsRunning = false;
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
            else if (IsGameOver && endGameScreen.Update()) IsGameOver = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRunning) startScreen.Draw(spriteBatch);
            else if (IsGameOver) endGameScreen.Draw(spriteBatch);
        }
    }
}