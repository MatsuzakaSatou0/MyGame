using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assimp.Metadata;

namespace MyGame002.MonoECS.Components
{
    public class Camera : Component
    {
        float size = 1.0f;
        Vector2 cameraPosition = new Vector2();
        Vector2 cameraSize = new Vector2(640, 360);
        Vector2 beforeResizedCameraPosition;
        Vector2 beforeResizedEntityPosition;
        Entity camera = new Entity();
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            
        }
        public float GetSize()
        {
            return size;
        }
        public bool GetPositionFromCamera(Entity entity,out Vector2 position)
        {
            Vector2 resizedCameraPosition = (cameraPosition * size);
            Vector2 resizedEntityPosition = ((resizedCameraPosition + entity.GetPosition() * size)- cameraSize/2) * size+ cameraSize / 2;
            Vector2 resizedCameraSize = cameraSize / size;

            resizedCameraPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedEntityPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedCameraSize *= Game1.GetInstance().GetScreenSizeMulti();


            if (resizedEntityPosition.X >= resizedCameraPosition.X)
            {
                if (resizedEntityPosition.X <= resizedCameraSize.X)
                {
                    if (resizedEntityPosition.Y >= resizedCameraPosition.Y)
                    {
                        if (resizedEntityPosition.Y <= resizedCameraSize.Y)
                        {
                            position = (resizedEntityPosition + resizedCameraPosition);
                            return true;
                        }
                    }
                }
            }
            position = new Vector2(0, 0);
            return false;
        }
        public void SetPosition(Vector2 position)
        {
            cameraPosition = position;
        }
        public List<Component> GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new List<Entity> {camera}.ToArray());
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                cameraPosition.X += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                cameraPosition.X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cameraPosition.Y += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cameraPosition.Y -= 1f;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                cameraPosition += cameraSize;
                size += 0.01f;
                cameraPosition -= cameraSize;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (size > 0.15f)
                {
                    size -= 0.01f;
                }
            }
        }
    }
}
