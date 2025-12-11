using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MonoECS.Components.GameAI;
using MyGame002.MonoECS.Components.PlayerController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Game.G1
{
    public class Game001 : GameBase
    {
        Entity entity = new Entity();
        List<Entity> enemies = new List<Entity>();
        Entity text = new Entity();

        PlayerChaser playerChaser;
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
        }

        public List<Component> GetComponents()
        {
            List<Entity> entities = new Entity[] { entity, text }.ToList();
            entities.AddRange(enemies);
            return EntityUtil.GetAllComponentsFromEntity(entities.ToArray());
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            //プレイヤー
            entity.AddComponent(new TextRender(entity, 1, "*", Color.Green));
            entity.AddComponent(new MousePlayerController(entity));
            for(int i = 0;i<=50;i++)
            {
                enemies.Add(new Entity());
            }
            //敵
            foreach (Entity enemy in enemies)
            {
                playerChaser = enemy.AddComponent(new PlayerChaser(enemy)) as PlayerChaser;
                enemy.AddComponent(new TextRender(enemy, 1, "!", Color.Red));
                Random random = new Random();
                enemy.SetPosition(new Vector2(random.Next(0, (int)Game1.GetInstance().GetCenter().X*2), random.Next(0, (int)Game1.GetInstance().GetCenter().Y * 2)));
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Entity enemy in enemies)
            {
                PlayerChaser playerChaser = enemy.GetComponent(typeof(PlayerChaser)) as PlayerChaser;
                playerChaser.SetChasePosition(entity.GetPosition());
            }
        }
    }
}
