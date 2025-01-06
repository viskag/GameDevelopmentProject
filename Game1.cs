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
        private Texture2D backgroundTexture;
        private SpriteFont font;
        public static int screenWidth = 1600;
        public static int screenHeight = 900;

        private Hero hero;
        private List<Level> levels = new List<Level>();

        private GameController gameControl;
        //REMINDER:
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

            
            levels.Add(new Level(Content.Load<Texture2D>("npc"), Content.Load<Texture2D>("./Elements/G3"), 3, 6, hero));
            levels.Add(new Level(Content.Load<Texture2D>("npc0"), Content.Load<Texture2D>("./Elements/G3"), 4, 8, hero));
            //civ = new Civilian(civTexture, 64, 64, Character.Direction.Down, 0, hero);
            //civ.position = new Vector2(30);
            //civ2 = new Civilian(civTexture, 64, 64, Character.Direction.Down, 1, hero);
            //civ2.position = new Vector2(60);
            //civ3 = new Civilian(civTexture, 64, 64, Character.Direction.Down, 2, hero);
            //civ3.position = new Vector2(600);

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