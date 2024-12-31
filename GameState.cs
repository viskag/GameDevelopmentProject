using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject
{
    internal class GameState
    {
        public bool IsRunning { get; set; }
        public bool IsGameOver { get; set; }
        public GameState()
        {
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
    }
}