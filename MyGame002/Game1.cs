using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using System.Collections.Generic;

namespace MyGame002
{
    public class Game1 : Game
    {
        private static Game1 _singleInstance = new Game1();
        public static Game1 GetInstance()
        {
            return _singleInstance;
        }

        public GraphicsDeviceManager _graphics;

        public SpriteBatch _spriteBatch;

        private SpriteFont _font;

        GameBase gameBase;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Game1.GetInstance().Window.Title = "Game";
            base.Initialize();

            foreach (Component component in gameBase.GetComponents())
            {
                component.Start();
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("anzmoji");
            // TODO: use this.Content to load your game content here
            }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            gameBase.Update(gameTime);
            base.Update(gameTime);
            foreach (Component component in gameBase.GetComponents())
            {
                component.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            Game1.GetInstance()._spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            
            // TODO: Add your drawing code here
            gameBase.Draw(gameTime);
            foreach (Component component in gameBase.GetComponents())
            {
                component.Draw(gameTime);
            }

            Game1.GetInstance()._spriteBatch.End();

        }
        public void RegisterGame(GameBase gameBase)
        {
            gameBase.Start();
            this.gameBase = gameBase;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(Game1.GetInstance().Window.ClientBounds.Width / 2, Game1.GetInstance().Window.ClientBounds.Height / 2);
        }
        public SpriteFont GetFont()
        {
            return _font;
        }
    }
}
