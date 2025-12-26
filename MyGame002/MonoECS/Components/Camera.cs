using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static Assimp.Metadata;

namespace MyGame002.MonoECS.Components
{
    public class Camera : Component
    {
        Vector2 beforeResizedCameraPosition;
        Vector2 beforeResizedEntityPosition;
        Entity camera = new Entity();
        private bool debugView = false;

        public float size = 1.0f;
        public Vector2 cameraPosition = new Vector2();
        public Vector2 cameraSize = new Vector2(640, 360);

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
            Vector2 resizedEntityPosition = (resizedCameraPosition + entity.GetPosition() * size - (cameraSize)) * size + (cameraSize);
            Vector2 resizedCameraSize = -resizedCameraPosition + (cameraSize);
            resizedCameraPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedEntityPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedCameraSize *= Game1.GetInstance().GetScreenSizeMulti();
            position = (resizedEntityPosition + resizedCameraPosition);
            return true;
        }
        public bool GetPositionFromCamera(Vector2 pos, out Vector2 position)
        {
            Vector2 resizedCameraPosition = (cameraPosition * size);
            Vector2 resizedEntityPosition = (resizedCameraPosition + pos * size - (cameraSize)) * size + (cameraSize);
            Vector2 resizedCameraSize = -resizedCameraPosition + (cameraSize);
            resizedCameraPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedEntityPosition *= Game1.GetInstance().GetScreenSizeMulti();
            resizedCameraSize *= Game1.GetInstance().GetScreenSizeMulti();
            position = (resizedEntityPosition + resizedCameraPosition);
            return true;
        }
        public Vector2 GetPosition(Vector2 position)
        {
            return cameraPosition;
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

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
