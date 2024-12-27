using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevelopmentProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D heroTexture;
        Hero hero;
        static public int screenWidth = 1600;//schermgrootte breedte
        static public int screenHeight = 900;//schermgrootte hoogte

        private Texture2D startScreenTexture;//REMINDER: NIET VERGETEN TEXTURE TOEVOEGEN!
        private SpriteFont font;
        private StartGamescreen startScreen;
        private bool running = false;

        //REMINDER: OOK ZELFDE ZOALS HIERBOVEN, TEXTURE VOOR GAMEOVERSCREEN NIET VERGETEN!
        private EndGamescreen endGameScreen;
        private bool gameOver = false;

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
            font = Content.Load<SpriteFont>("DefaultFont");
            startScreen = new StartGamescreen(font);
            endGameScreen = new EndGamescreen(font);

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(heroTexture, 66, 66, Hero.Direction.Down);
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (!running)
            {
                running = startScreen.Update();
            }
            else if (gameOver)
            {
                if (endGameScreen.Update())
                {
                    // reset gameover
                    gameOver = false;

                    // reset alle informatie
                    // hero = new Hero();       // reset de hero
                                                // nog andere resets die in te toekomst zullen komen
                }
            }
            else
            {
                // continue...
                hero.Update(gameTime);

                // tijdelijke testkey 'X' voor gameOver screen te tonen
                if (Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    gameOver = true; // Set game over state
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PowderBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (!running)
            {
                startScreen.Draw(_spriteBatch);
            }
            else if (gameOver) 
            {
                endGameScreen.Draw(_spriteBatch);
            }
            else
            {
                hero.Draw(_spriteBatch);
            }

            //hero.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}