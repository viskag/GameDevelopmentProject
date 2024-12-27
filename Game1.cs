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

        private Texture2D startScreenTexture;
        private SpriteFont font;
        private Startscreen startScreen;
        private bool running = false;

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
            startScreen = new Startscreen(font);

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
                running = startScreen.Update(); // Check if the start screen should transition to the game
            }
            else
            {
                hero.Update(gameTime); // Update the hero if the game has started
            }
            //hero.Update(gameTime);

            base.Update(gameTime);
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