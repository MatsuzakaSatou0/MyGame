using Assimp;
using GlmSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoCV;
using MyGame002.MonoECS;
using MyGame002.MyData;
using OpenCvSharp;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static OpenCvSharp.LineIterator;
using static System.Net.Mime.MediaTypeNames;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;
/*
 * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 * 実験的に開発中！テクスチャ機能を開発中ですが、実装に失敗しています。
 * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 */
namespace MyGame002.My3dEngine.Renderer
{
    public class Vertex
    {
        vec2 uv;
        vec4 position;
        public float u
        {
            get { return uv.x; }
        }
        public float one_over_w
        {
            get { return 1/position.w; }
        }
        public float x
        {
            get { return position.x; }
        }
        public float y
        {
            get { return position.y; }
        }
        public float z
        {
            get { return position.z; }
        }
        public float v
        {
            get { return uv.y; }
        }

        public Vertex(vec2 uv, vec4 position)
        {
            this.uv = uv;
            this.position = position;
        }
        public vec4 GetPosition()
        {
            return position;
        }
    }
    public class Renderer : Component
    {
        private float tn = 0;
        List<Vertex> vertex = new List<Vertex>() { new Vertex(new vec2(1,0),new vec4(0.5f, -0.0f, 0, 1)), new Vertex(new vec2(0.5f, 0.35f), new vec4(-0.5f, -0.0f, 0, 1)), new Vertex(new vec2(0, 0), new vec4(0.0f, -1.0f, 0, 1)) };
        private int height;
        private int width;
        Color[] data;
        private float fov = 45;
        private float aspectRatio = 1.88f;
        private float nearPlane = 0.1f;
        private float farPlane = 100.0f;
        private float beforeMouseX = 0.0f;
        private float beforeMouseY = 0.0f;
        vec3 cameraAngle = new vec3(280, 1, 0);
        vec3 cameraPosition = new vec3(0, 1, 6);
        public void Draw(GameTime time)
        {
            Render();
        }
        public vec3 GetPosition()
        {
            return cameraPosition;
        }
        public vec3 GetRotation()
        {
            return cameraAngle;
        }
        private Vector2 CalcNDC(mat4 model, vec4 position)
        {
            GlmSharp.vec4 clip = model * position;
            vec3 ndc = vec3.Zero;
            if (clip.w != 0.0f)
            {
                ndc.x = clip.x / clip.w;
                ndc.y = clip.y / clip.w;
                ndc.z = clip.z / clip.w;
            }
            Vector2 screenPos = new Vector2((int)(((ndc.x + 1) / 2) * width), (int)(((ndc.y + 1) / 2) * height));
            return screenPos;
        }
        public void Render()
        {
            tn += 15f;
            height = 340;
            width = 640;
            aspectRatio = width / height;

            data = new Color[(int)(height * width)];
            mat4 model = mat4.Zero;
            vec3 translate = new vec3(0.5f, 0.0f, 0.0f);
            vec3 rotate = new vec3(0.00f, 1.00f, 0.00f);
            vec3 scale = new vec3(1.0f, 1.0f, 1.0f);

            GlmSharp.mat4 projection = mat4.Perspective(fov, aspectRatio, nearPlane, farPlane);
            mat4 t = GlmSharp.mat4.Translate(translate);
            mat4 r = GlmSharp.mat4.Rotate(glm.Radians(tn), rotate);
            mat4 s = GlmSharp.mat4.Scale(scale);

            vec3 front;
            front.x = MathF.Cos(glm.Radians(cameraAngle.x)) * MathF.Cos(glm.Radians(cameraAngle.y));
            front.y = MathF.Sin(glm.Radians(cameraAngle.y));
            front.z = MathF.Sin(glm.Radians(cameraAngle.x)) * MathF.Cos(glm.Radians(cameraAngle.y));

            mat4 view = mat4.LookAt(
                cameraPosition,
                cameraPosition + (front.Normalized),
                new vec3(0.0f, 1.0f, 0.0f)
            );

            model = t * r * s;
            Texture2D gameTexture = new Texture2D(Game1.GetInstance().GraphicsDevice, width, height);
            mat4 model2 = projection * view * model;

            MyDataFile myDataFile = new MyDataFile();
            myDataFile.Load("yukari_data.mgf");
            Mat texture = myDataFile.UnpackTextureData()["Cube"];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 screenPos = CalcNDC(model2, vertex[0].GetPosition());
                    Vector2 screenPos1 = CalcNDC(model2, vertex[1].GetPosition());
                    Vector2 screenPos2 = CalcNDC(model2, vertex[2].GetPosition());
                    //カラーデータを設定
                    if (IsPosInScreen(screenPos))
                    {
                        if (IsPosInScreen(screenPos1))
                        {
                            if (IsPosInScreen(screenPos2))
                            {
                                if (isInside(new Vector2(x, y), screenPos, screenPos1, screenPos2))
                                {
                                    data[(int)(y * width + x)] = fragmentShader(x,y, vertex[0], vertex[1], vertex[2],texture);
                                }
                                else
                                {
                                    //data[(int)(y * width + x)] = new Color(0, 255, 0, 255);
                                }
                            }
                        }
                    }
                }
            }
            gameTexture.SetData<Color>(0, new Rectangle(0, 0, width, height), data, 0, width * height);
            Game1.GetInstance()._spriteBatch.Draw(gameTexture,
                Microsoft.Xna.Framework.Vector2.Zero,
                new Rectangle(0, 0, width, height),
                Color.White,
                0,
                new Microsoft.Xna.Framework.Vector2(0, 0),
                1 * Game1.GetInstance().GetScreenSizeMulti(),
                SpriteEffects.FlipVertically, 0);
        }
        Color fragmentShader(
            int pixel_x, int pixel_y,
            Vertex v1, Vertex v2, Vertex v3,
            Mat texture
        ) {
            Vector3 abg = computeBarycentricCoordinates(pixel_x, pixel_y, v1, v2, v3, texture);
            float alpha = abg.X;
            float beta = abg.Y;
            float gamma = abg.Z;
            float U_prime_frag = alpha * (v1.u * v1.one_over_w) +
                                 beta * (v2.u * v2.one_over_w) +
                                 gamma * (v3.u * v3.one_over_w);

            float V_prime_frag = alpha * (v1.v * v1.one_over_w) +
                                 beta * (v2.v * v2.one_over_w) +
                                 gamma * (v3.v * v3.one_over_w);

            float W_prime_frag = alpha * v1.one_over_w +
                                 beta * v2.one_over_w +
                                 gamma * v3.one_over_w;

            float U_frag = U_prime_frag / W_prime_frag;
            float V_frag = V_prime_frag / W_prime_frag;

            // 3. テクスチャサンプリング
            Color finalColor = sampleTexture(texture, U_frag, V_frag);

            return finalColor;
        }
        Vector3 computeBarycentricCoordinates(int px,int py,Vertex v1,Vertex v2,Vertex v3, Mat texture)
        {
            EdgeCoefficients e12 = calculateEdgeCoefficients(v1.x, v1.y, v2.x, v2.y);
            EdgeCoefficients e23 = calculateEdgeCoefficients(v2.x, v2.y, v3.x, v3.y);
            EdgeCoefficients e31 = calculateEdgeCoefficients(v3.x, v3.y, v1.x, v1.y);

            float A_total = evaluateEdge(e12, v3.x, v3.y);

            float alpha = evaluateEdge(e23, px, py);
            float beta = evaluateEdge(e31, px, py);
            float gamma = evaluateEdge(e12, px, py);

            return new Vector3(alpha / A_total, beta / A_total, gamma / A_total);
        }
        Color sampleTexture(Mat tex, float u, float v) {
            int x = (int)(u * ((float)tex.Width - 1));
            int y = (int)(v * ((float)tex.Height - 1));
            if (x >= 0 && x<tex.Width && y >= 0 && y<tex.Height)
            {
                Vec3b col = tex.At<Vec3b>(x, y);
                return new Color(col.Item0,col.Item1, col.Item2);
            }
            return new Color(255, 0, 255); // デフォルト色
        }
    struct EdgeCoefficients
        {
            float _A, _B, _C;
            public float A
            {
                get { return this._A; }
            }
            public float B
            {
                get { return _B; }
            }
            public float C
            {
                get { return _C; }
            }
            public EdgeCoefficients (float A, float B, float C)
            {
                this._A = A;
                this._B = B;
                this._C = C;
            }
        };
        EdgeCoefficients calculateEdgeCoefficients(
        float x1, float y1, float x2, float y2)
        {
            // E(x, y) = A*x + B*y + C
            return new EdgeCoefficients
            (
                y1 - y2,
                x2 - x1,
                x1 * y2 - x2 * y1
            );
        }
        float evaluateEdge(EdgeCoefficients edge, float x, float y) {
            return edge.A* x + edge.B* y + edge.C;
        }
        private bool IsPosInScreen(Vector2 pos)
        {
            if (pos.X < 0.0f)
            {
                return false;
            }
            if (pos.Y < 0.0f)
            {
                return false;
            }
            if (width < pos.X)
            {
                return false;
            }
            if (width < pos.Y)
            {
                return false;
            }
            return true;
        }

        float edgeFunction(Vector2 a, Vector2 b, Vector2 c)
        {
            return (c.X - a.X) * (b.Y - a.Y) - (c.Y - a.Y) * (b.X - a.X);
        }
        private bool isInside(Vector2 p, Vector2 v0, Vector2 v1, Vector2 v2)
        {
            float w0 = edgeFunction(v1, v2, p);
            float w1 = edgeFunction(v2, v0, p);
            float w2 = edgeFunction(v0, v1, p);
            return (w0 >= 0 && w1 >= 0 && w2 >= 0);
        }
        private void DrawLine(Vector2 screenPos1, Vector2 screenPos2)
        {
            if (!IsPosInScreen(screenPos1) || !IsPosInScreen(screenPos2))
            {
                return;
            }
            float dx = screenPos2.X - screenPos1.X;
            float dy = screenPos2.Y - screenPos1.Y;
            if (dx != 0)
            {
                float m = dy / dx;
                for (int i2 = 0; i2 <= dx + 1; i2++)
                {
                    if (data.Length >= ((int)screenPos1.Y + i2) * width + ((int)(screenPos1.X + i2 * m)))
                    {
                        data[((int)screenPos1.Y + i2) * width + ((int)(screenPos1.X + i2 * m))] = new Color(255, 255, 255, 255);
                    }
                }
            }
        }
        public void Start()
        {

        }

        public void Update(GameTime time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                cameraAngle.y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                cameraAngle.y += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                cameraAngle.x -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                cameraAngle.x += 1f;
            }
            beforeMouseX = Microsoft.Xna.Framework.Input.Mouse.GetState().X;
            beforeMouseY = Microsoft.Xna.Framework.Input.Mouse.GetState().Y;
        }
    }
}
