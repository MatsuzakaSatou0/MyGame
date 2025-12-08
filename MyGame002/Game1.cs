using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace MyGame002
{
    public class Game1 : Game
    {
        private static Game1 _singleInstance = new Game1();
        public static Game1 GetInstance()
        {
            return _singleInstance;
        }

        private bool developmentMode = false;

        private float screenSizeMultiplier = 1f;

        public GraphicsDeviceManager _graphics;

        public SpriteBatch _spriteBatch;

        private bool isStopping = false;

        private SpriteFont _font;

        private ProgramManager programManager;

        GameBase gameBase;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            programManager = new ProgramManager();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void BeginRun()
        {
            base.BeginRun();
            if(IsDevelopmentMode())
            {
                DevelopMenu developMenu = new DevelopMenu();
                developMenu.Show();
            }
            foreach (Component component in gameBase.GetComponents())
            {
                component.Start();
            }
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Game";
            //画面設定
            //_graphics.ToggleFullScreen();
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 340;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("anzmoji");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if(isStopping)
            {
                return;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            gameBase.Update(gameTime);
            foreach (Component component in gameBase.GetComponents())
            {
                component.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (isStopping)
            {
                Game1.GetInstance()._spriteBatch.Begin();
                base.Draw(gameTime);
                Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), DebugTool.GetInstance().GetLastMessage(), new Vector2(0,0), Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0), 1, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
                Game1.GetInstance()._spriteBatch.End(); 
                return;
            }
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
            if (this.gameBase != null)
            {
                this.gameBase.Dispose();
            }
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
        public void StopGame()
        {
            isStopping = true;
        }
        public void StartGame()
        {
            isStopping = false;
        }
        public float GetScreenSizeMulti()
        {
            return screenSizeMultiplier;
        }
        public void SetScreenSizeMulti(float value)
        {
            _graphics.PreferredBackBufferWidth = (int)(640 * screenSizeMultiplier);
            _graphics.PreferredBackBufferHeight = (int)(360 * screenSizeMultiplier);
            _graphics.ApplyChanges();
            screenSizeMultiplier = value;
        }
        public bool IsDevelopmentMode()
        {
            return developmentMode;
        }
        public ProgramManager GetProgramManager()
        {
            return programManager;
        }
    }
}
