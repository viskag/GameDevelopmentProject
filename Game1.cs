using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
//using SharpDX.Direct2D1;
//using SharpDX.Direct2D1;

namespace GameDevelopmentProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backgroundTexture;

        private Texture2D heroTexture;
        private Hero hero;

        static public int screenWidth = 1600;
        static public int screenHeight = 900;

        private Texture2D startScreenTexture;//REMINDER: NIET VERGETEN TEXTURE TOEVOEGEN!
        private SpriteFont font;
        private StartGamescreen startScreen;
        private bool running = false;

        //REMINDER: OOK ZELFDE ZOALS HIERBOVEN, TEXTURE VOOR GAMEOVERSCREEN NIET VERGETEN!
        private EndGamescreen endGameScreen;
        private bool gameOver = false;

        private Texture2D coinTexture;
        private Coin coin;

        private Texture2D civTexture;
        private Civilian civ;
        private Civilian civ2;
        private Civilian civ3;

        private List<Level> levels = new List<Level>();
        private int currLevel = 0;

        private GameState gameState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            heroTexture = Content.Load<Texture2D>("assangesprite");
            coinTexture = Content.Load<Texture2D>("./Elements/G3");
            civTexture = Content.Load<Texture2D>("npc");
            backgroundTexture = Content.Load<Texture2D>("ice");

            font = Content.Load<SpriteFont>("DefaultFont");
            startScreen = new StartGamescreen(font);
            endGameScreen = new EndGamescreen(font);

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(heroTexture, 66, 66, Character.Direction.Down);
            //coin = new Coin(coinTexture, new Vector2(500, 500), 64, 64);
            civ = new Civilian(civTexture, 64, 64, Character.Direction.Down, 0, hero);
            civ.position = new Vector2(30);
            civ2 = new Civilian(civTexture, 64, 64, Character.Direction.Down, 1, hero);
            civ2.position = new Vector2(60);
            civ3 = new Civilian(civTexture, 64, 64, Character.Direction.Down, 2, hero);
            civ3.position = new Vector2(600);

            levels.Add(new Level(coinTexture, 5, 6, hero));
            levels.Add(new Level(coinTexture, 10, 10, hero));

            gameState = new GameState(font);
        }

        protected override void Update(GameTime gameTime)
        {
            gameState.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.X)) gameState.EndGame();

            if (!gameState.IsRunning) return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);

            civ.Update(gameTime); civ2.Update(gameTime); civ3?.Update(gameTime);

            levels[currLevel].Update(gameTime);

            if (levels[currLevel].AllCollected() && currLevel + 1 < levels.Count)
            {
                currLevel += 1;
                gameState.IsRunning = false;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PowderBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            gameState.Draw(_spriteBatch);
            if (!gameState.IsGameOver && gameState.IsRunning)
            {

                levels[currLevel].Draw(_spriteBatch);

                hero.Draw(_spriteBatch);

                civ.Draw(_spriteBatch); civ2.Draw(_spriteBatch); civ3.Draw(_spriteBatch);
            }

            _spriteBatch.DrawString(font, $"Levens: {hero.lives} Munten: {levels[currLevel].coinManager.coins.Count}", new Vector2(10, 10), Color.Green);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}