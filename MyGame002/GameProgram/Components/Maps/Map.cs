using CppNet;
using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.ExampleRPG.Tales;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.Maps
{
    public class Map
    {


        private Camera camera;
        private Tale tale;
        /*
        private Tile tile;
        private Tile tile2;
        */
        private RPGGame game;
        private int width = 50;
        private int height = 50;
        private MyDataFile mapFile = new MyDataFile();
        public Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();
        public Map(RPGGame game)
        {
            this.game = game;
            /*
            //Mapのファイルを読み込み
            mapFile.Load("Map.mdf");
            //タイルを設定
            tile = new Tile("Concrete.png", mapFile);
            tile2 = new Tile("None.png", mapFile);
            this.camera = camera;
            tile2.SetFlag(TileFlag.Wall);
            Random random = new Random(1);
            for (int x = 0; x <= width; x++)
            {
                for (int y = 0; y <= height; y++)
                {
                    if (random.Next() % 15 != 0)
                    {
                        tiles.Add(new Vector2(x, y), tile);
                    }
                    else
                    {
                        tiles.Add(new Vector2(x, y), tile2);
                    }
                }
            }
            tale = new ExampleParentTale(camera, this, mapFile);
            */
        }
        public virtual RPGGame GetGame()
        {
            return game;
        }
        public virtual Vector2 GetSize()
        {
            return new Vector2(width,height);
        }
        public virtual Tale GetTale()
        {
            return tale;
        }
        public virtual List<Tale> GetTales()
        {
            return new List<Tale>() {tale };
        }
    }
}