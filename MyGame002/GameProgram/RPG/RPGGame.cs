using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.Components;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.Components.RPGRender;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame002.GameProgram.RPG
{
    public class RPGGame : GameBase
    {
        MyDataFile dataFile = new MyDataFile();
        MyDataFile mapFile = new MyDataFile();
        //初期化用
        private bool isInitialized = false;

        private bool isTutorial = false;
        //チュートリアル用
        private int tutorialPage = 0;
        //エンティティー
        Entity tutorialText = new Entity();
        Entity tutorial = new Entity();

        Entity tileRender = new Entity();
        Entity camera = new Entity();
        Entity mouseEntity = new Entity();

        Map map = new Map(50, 50);
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            
        }

        public List<Component> GetComponents()
        {
            List<Entity> finalEntity = new List<Entity>();
            finalEntity.AddRange(new List<Entity>() { tileRender, camera, mouseEntity });
            return EntityUtil.GetAllComponentsFromEntity(finalEntity.ToArray());
        }

        public void Initialize()
        {
            //ファイル読み込み
            mapFile.Load("Map.mdf");
            dataFile.Load("MonoUI.mdf");
            isTutorial = true;
            //テクスチャ
            var texture = mapFile.TryGetTexture("texture_demo.png");
            //コンポーネント
            camera.AddComponent(new RPGCamera());
            tileRender.AddComponent(new TileRender(tileRender, map, mapFile, camera.GetComponentAndConvert<RPGCamera>()));
            //マウス
            mouseEntity.AddComponent(new MousePlayerController(mouseEntity));
            mouseEntity.AddComponent(new TextureRender(mouseEntity, dataFile.TryGetTexture("MouseCursor.png"), new Vector2(30, 30), 1));
        }

        public void Start()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            //初期化呼び出し
            if(!isInitialized)
            {
                Initialize();
                isInitialized = true;
            }
        }
    }
}
