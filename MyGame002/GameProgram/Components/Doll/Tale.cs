using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.Doll
{
    public class Tale
    {
        private RPGGame game;
        private MyDataFile mapFile = new MyDataFile();
        private List<Entity> puppets = new List<Entity>();
        private int currentTaleIndex = 0;
        private bool isEnd = false;
        private List<Tale> tales = new List<Tale>();
        public Tale(RPGGame game, Map map,MyDataFile mapFile)
        {
            this.game = game;
            this.mapFile = mapFile;
        }
        public virtual bool TaleCheck()
        {
            return false;
        }
        public virtual void Progress()
        {
            game.AddTime(1);
            if (currentTaleIndex < tales.Count) {
                if (tales[currentTaleIndex].IsEnd() == true)
                {
                    currentTaleIndex += 1;
                    return;
                }
                tales[currentTaleIndex].Progress();
            }
        }
        public void AddTale(Tale tale)
        {
            tales.Add(tale);
        }
        public Entity AddPuppet(string texture)
        {
            Entity puppet = new Entity();
            puppet.AddComponent(new PuppetDoll(puppet, game.GetCamera(), texture, mapFile));
            puppets.Add(puppet);
            return puppet;
        }
        public void CallEnd()
        {
            isEnd = true;
        }
        public bool IsEnd()
        {
            return isEnd;
        }
        public List<Component> GetCharacterComponent()
        {
            List<Component> entities = new List<Component>();
            foreach(Tale t in tales)
            {
                entities.AddRange(t.GetCharacterComponent());
            }
            foreach (Entity puppet in puppets)
            {
                entities.AddRange(puppet.GetComponents());
            }
            return entities;
        }
    }
}
