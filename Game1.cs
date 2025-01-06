using GameDevelopmentProject.Characters;
using GameDevelopmentProject.MapElements;
using GameDevelopmentProject.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameDevelopmentProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int screenWidth = 1600;
        public static int screenHeight = 900;

        private Texture2D backgroundTexture;
        private SpriteFont font;

        private Hero hero;
        private List<Level> levels = new List<Level>();

        private GameController gameControl;
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

            font = Content.Load<SpriteFont>("DefaultFont");
            backgroundTexture = Content.Load<Texture2D>("ice");
            hero = new Hero(Content.Load<Texture2D>("assangesprite"), 66, 66, Character.Direction.Down);

            levels.Add(new Level(Content.Load<Texture2D>("npc"), Content.Load<Texture2D>("./Elements/G3"), 1, 2, hero));
            levels.Add(new Level(Content.Load<Texture2D>("npc0"), Content.Load<Texture2D>("./Elements/G3"), 2, 3, hero));
            levels.Add(new Level(Content.Load<Texture2D>("npc7"), Content.Load<Texture2D>("./Elements/G3"), 3, 4, hero));

            gameControl = new GameController(font, hero, levels);
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            gameControl.HandleExit();
            gameControl.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PowderBlue);

            // TODO: Add your drawing code here

            gameControl.Draw(_spriteBatch, backgroundTexture);
        }
    }
}