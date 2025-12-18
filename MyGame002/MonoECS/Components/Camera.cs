using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        private bool debugView = false;
        public void Dispose()
        {

        }
        public void TurnDebugMode()
        {
            debugView = !debugView;
        }

        public void Draw(GameTime gameTime)
        {
            Vector2 resizedCameraPosition = (cameraPosition * size);
            Vector2 resizedEntityPosition = ((resizedCameraPosition * size) - cameraSize) * size + cameraSize;
            Vector2 resizedCameraSize = cameraSize / size;
            resizedCameraPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedEntityPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedCameraSize *= Game1.GetInstance().GetScreenSizeMulti();
        }
        public float GetSize()
        {
            return size;
        }
        public bool GetPositionFromCamera(Entity entity, out Vector2 position)
        {
            Vector2 resizedCameraPosition = (cameraPosition * size);
            Vector2 resizedEntityPosition = (resizedCameraPosition + entity.GetPosition() * size - cameraSize) * size + cameraSize;
            Vector2 resizedCameraSize = -resizedCameraPosition + (cameraSize);
            resizedCameraPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedEntityPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedCameraSize *= Game1.GetInstance().GetScreenSizeMulti();

            Game1.GetInstance().PrintDebug(resizedCameraSize.X + "\n");
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
            return EntityUtil.GetAllComponentsFromEntity(new List<Entity> { camera }.ToArray());
        }

        public void Initialize()
        {

        }

        public void Start()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                cameraPosition.X += 3f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                cameraPosition.X -= 3f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cameraPosition.Y += 3f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cameraPosition.Y -= 3f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                if (size < 1.0f)
                {
                    size += 0.01f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (size > 0.15f)
                {
                    size -= 0.01f;
                }
            }
        }
    }
}
