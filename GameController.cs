using GameDevelopmentProject.Characters;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GameDevelopmentProject
{
    internal class GameController
    {
        private SpriteFont font;
        private Hero hero;
        private List<Level> levels;
        public static int currLevel;
        private GameState gameState;

        public GameController(SpriteFont font, Hero hero, List<Level> levels)
        {
            this.font = font;
            this.hero = hero;
            this.levels = levels;
            currLevel = 0;
            this.gameState = new GameState(font, hero);
        }

        public void Update(GameTime gameTime)
        {
            
            if (hero.lives == 0)
            {
                gameState.EndGame();
                ResetLevel();
            }

           
            if (currLevel + 1 == levels.Count && levels[currLevel].AllCollected())
            {
                gameState.WinGame();
                return;
            }

            
            gameState.Update();

            if (!gameState.IsRunning) return;

            
            hero.Update(gameTime);
            levels[currLevel].Update(gameTime);

            
            if (levels[currLevel].AllCollected() && currLevel + 1 < levels.Count)
            {
                currLevel += 1;
                hero.civs.Clear();
                gameState.IsRunning = false;
                LoadLevel(currLevel);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D backgroundTexture)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Game1.screenWidth, Game1.screenHeight), Color.White);
            gameState.Draw(spriteBatch);

            if (!gameState.IsGameOver && gameState.IsRunning)
            {
                levels[currLevel].Draw(spriteBatch);
                hero.Draw(spriteBatch);
            }

            spriteBatch.DrawString(font, $"LvL {currLevel + 1}", new Vector2(10, 10), Color.Green);
            spriteBatch.DrawString(font, $"Levens:{hero.lives} Munten:{levels[currLevel].coinManager.coins.Count}", new Vector2(500, 10), Color.Green);
            spriteBatch.End();
        }

        private void ResetLevel()
        {
            levels[currLevel].coinManager.coins.Clear();
            levels[currLevel].civilianManager.civilians.Clear();
            levels[currLevel].LevelSetup();
        }

        private void LoadLevel(int levelIndex)
        {
            foreach (Civilian civ in levels[levelIndex].civilianManager.civilians)
            {
                hero.civs.Add(civ);
            }
        }

        public void HandleExit()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.X)) gameState.EndGame();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Environment.Exit(0);
        }
    }
}
