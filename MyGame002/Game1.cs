using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MyGame002
{
    public class Game1 : Game
    {
        //シングルトン
        private static Game1 _singleInstance = new Game1();
        public static Game1 GetInstance()
        {
            return _singleInstance;
        }
        //開発用モードのフラグ
        private bool developmentMode = true;
        //スクリーンのサイズの比率
        private float screenSizeMultiplier = 1f;
        //グラフィック
        public GraphicsDeviceManager _graphics;
        //スプライトのバッチ
        public SpriteBatch _spriteBatch;
        //ゲームが強制的に停止しているか。
        private bool isStopping = false;
        //スプライトのフォント
        private SpriteFont _font;
        //プログラム選択のオブジェクト
        private ProgramManager programManager;
        //ゲームのインターフェース
        GameBase gameBase;


        public Game1()
        {
            //**MonoGame**の初期化
            //グラフィックデバイスを初期化
            //https://docs.monogame.net/api/Microsoft.Xna.Framework.GraphicsDeviceManager.html
            _graphics = new GraphicsDeviceManager(this);
            //コンテンツのフォルダーを変更
            //主にフォント関連の入ってるファルダーを指定
            Content.RootDirectory = "Content";
            //マウスが表示されているかどうか
            IsMouseVisible = true;
            //プログラム選択のオブジェクト
            programManager = new ProgramManager();
        }
        //MonoGame側の初期化
        protected override void BeginRun()
        {
            //始まったら
            base.BeginRun();
            if (gameBase == null)
            {
                return;
            }
            //マウスの描画をfalseにする。
            this.IsMouseVisible = false;
            //開発用モードがオンの場合
            if(IsDevelopmentMode())
            {
                //開発用のウィンドウを表示
                DevelopMenu developMenu = new DevelopMenu();
                developMenu.Show();
            }
            //全コンポーネントの初期化処理を実行
            foreach (Component component in gameBase.GetComponents())
            {
                component.Start();
            }
        }

        //MonoGame側の初期化（グラフィック側）
        protected override void Initialize()
        {
            //ウィンドウのタイトル
            Window.Title = "2025年度 進級制作 MyGame 齊藤陽生";
            //画面設定
            //ゲームのサイズ 16:9です。
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 360;
            //グラフィック設定の変更を適応します。これを実行しないと変更されないです。
            _graphics.ApplyChanges();
            //ゲームベースの初期化
            if(gameBase == null)
            {
                MessageBox.Show("プログラムが初期化されませんでした。Programsフォルダーに適切なプログラムがあることを確認してください。");
                this.Exit();
                return;
            }
            gameBase.Initialize();
            base.Initialize();
        }
        //MonoGame側のコンテンツの読み込み
        protected override void LoadContent()
        {
            //スプライトバッチを用意
            //https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //コンテンツをロード
            _font = Content.Load<SpriteFont>("Misaki");
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameBase == null)
            {
                return;
            }
            //止まっているか
            if (isStopping)
            {
                return;
            }
            //エスケープキーで閉じれるようにする。
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //ゲームのインターフェースの更新処理を実行
            gameBase.Update(gameTime);
            //全コンポーネントの更新処理を実行
            foreach (Component component in gameBase.GetComponents())
            {
                component.Update(gameTime);
            }
            //MonoGame側の更新処理を実行
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (gameBase == null)
            {
                return;
            }
            //停止しているか
            if (isStopping)
            {
                /*
                 * 緊急停止用の処理。（今はほとんど使っていません。）
                 */
                //スプライトの描画開始
                Game1.GetInstance()._spriteBatch.Begin();
                //描画
                base.Draw(gameTime);
                //トレースを表示
                Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), DebugTool.GetInstance().GetLastMessage(), new Vector2(0,0), Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0), 1, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
                //スプライトバッチ
                Game1.GetInstance()._spriteBatch.End(); 
                return;
            }
            //スプライトバッチの描画開始
            Game1.GetInstance()._spriteBatch.Begin();
            //スプライトの背景を初期化（glClearと同等なので、実行しないと残像が発生する。）
            GraphicsDevice.Clear(Color.Black);
            //ゲームの基礎の描画
            gameBase.Draw(gameTime);
            //全コンポーネントの描画を実行
            foreach (Component component in gameBase.GetComponents())
            {
                //コンポーネントを描画
                component.Draw(gameTime);
            }
            //基礎クラスを描画
            base.Draw(gameTime);
            //スプライトバッチの描画終了
            Game1.GetInstance()._spriteBatch.End();
        }
        //ゲームの登録
        public void RegisterGame(GameBase gameBase)
        {
            //ゲームのベースがnullならば
            if (this.gameBase != null)
            {
                this.gameBase.Dispose();
            }
            //ゲームベースの開始
            gameBase.Start();
            gameBase.Initialize();
            this.gameBase = gameBase;
        }
        /// <summary>
        /// ゲームのウィンドウの中央を取得
        /// </summary>
        public Vector2 GetCenter()
        {
            return new Vector2(Game1.GetInstance().Window.ClientBounds.Width / 2, Game1.GetInstance().Window.ClientBounds.Height / 2);
        }
        /// <summary>
		/// プログラムを追加
		/// </summary>
        public SpriteFont GetFont()
        {
            return _font;
        }
        /// <summary>
		/// プログラムを停止
		/// </summary>
        public void StopGame()
        {
            isStopping = true;
        }
        /// <summary>
		/// プログラムを開始
		/// </summary>
        public void StartGame()
        {
            isStopping = false;
        }
        /// <summary>
		/// 画面のサイズの倍率を取得
		/// </summary>
        public float GetScreenSizeMulti()
        {
            return screenSizeMultiplier;
        }
        /// <summary>
		/// 画面のサイズの倍率を設定
		/// </summary>
		/// <param name="value">倍率</param>
        public void SetScreenSizeMulti(float value)
        {
            _graphics.PreferredBackBufferWidth = (int)(640 * screenSizeMultiplier);
            _graphics.PreferredBackBufferHeight = (int)(360 * screenSizeMultiplier);
            _graphics.ApplyChanges();
            screenSizeMultiplier = value;
        }
        /// <summary>
		/// 開発モードかどうかを取得
		/// </summary>
        public bool IsDevelopmentMode()
        {
            return developmentMode;
        }
        /// <summary>
		/// プログラムのマネージャー
		/// </summary>
        public ProgramManager GetProgramManager()
        {
            return programManager;
        }
    }
}
