using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.Components;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.Components.RPGPlayer;
using MyGame002.GameProgram.Components.RPGRender;
using MyGame002.GameProgram.DemoGame.Maps;
using MyGame002.GameProgram.Log;
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
        private int time = 0;

        MyDataFile dataFile = new MyDataFile();
        MyDataFile mapFile = new MyDataFile();
        //初期化用
        private bool isInitialized = false;

        Entity player = new Entity();
        Entity logRender = new Entity();

        Entity tileRender = new Entity();
        Entity camera = new Entity();
        Entity mouseEntity = new Entity();

        GameLog gameLog;

        TileRender tileRenderComponent;

        Map map;
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            
        }

        public List<Component> GetComponents()
        {
            List<Component> components = new List<Component>();
            List<Entity> finalEntity = new List<Entity>();
            foreach (Tale tale in map.GetTales())
            {
                components.AddRange(tale.GetCharacterComponent());
            }
            finalEntity.AddRange(new List<Entity>() { tileRender, camera, mouseEntity, player ,logRender});
            components.AddRange(EntityUtil.GetAllComponentsFromEntity(finalEntity.ToArray()));
            return components;
        }

        public void Initialize()
        {
            //ファイル読み込み
            dataFile.Load("RPG.mdf");
            //コンポーネント
            camera.AddComponent(new RPGCamera());

            SetMap(new DG_MapEntry(this));

            gameLog = new GameLog(logRender, true, dataFile);
            logRender.AddComponent(gameLog);

            player.AddComponent(new GamePlayer(player,camera.GetComponentAndConvert<RPGCamera>(),dataFile,"Player.png",map));
        }
        public void InitializeGraphics()
        {
            mouseEntity.AddComponent(new MousePlayerController(mouseEntity));
            mouseEntity.AddComponent(new TextureRender(mouseEntity, dataFile.TryGetTexture("MouseCursor.png"), new Vector2(30, 30), 1.0f));
        }
        public void SetMap(Map map)
        {
            this.map = map;
            if (GetPlayerComponent() != null)
            {
                GetPlayerComponent().SetMap(map);
            }
            if (tileRenderComponent != null)
            {
                tileRenderComponent.ClearMap();
                tileRender.RemoveComponent(tileRenderComponent);
            }
            tileRenderComponent = new TileRender(tileRender, map, mapFile, camera.GetComponentAndConvert<RPGCamera>());
            tileRender.AddComponent(tileRenderComponent);
        }

        public void Start()
        {
            
        }
        public GameLog GetGameLog()
        {
            return gameLog;
        }
        public Camera GetCamera()
        {
            return camera.GetComponentAndConvert<RPGCamera>();
        }
        public Entity GetPlayer()
        {
            return player;
        }
        public GamePlayer GetPlayerComponent()
        {
            return player.GetComponentAndConvert<GamePlayer>();
        }
        public void Update(GameTime gameTime)
        {
            //初期化呼び出し
            if(!isInitialized)
            {
                InitializeGraphics();
                isInitialized = true;
            }
            if((gameTime.TotalGameTime.Milliseconds % 1000) == 0)
            {
                map.GetTale().Progress();
            }
        }
        public void AddTime(int t)
        {
            this.time += t;
            Logger.GetInstance().Log(this.time.ToString());
        }
    }
}
