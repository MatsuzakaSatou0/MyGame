using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace MyGame002.GameProgram.System
{
    public class ProgramSelector : GameBase
    {
        //自動ゲーム起動システムのフラグ
        private bool autoGameLaunch = false;
        //自動ゲーム起動のターゲット名
        private string autoGameLaunchTarget = "";

        //キー入力用のシステム
        KeyboardSystem keyboardSystem;
        //ユーザーからのキーボード入力
        TextRender inputTextRender;
        //画面上部に表示されるメッセージ
        TextRender messageRender;

        //メッセージのエンティティ
        Entity message = new Entity();
        //キーボード入力のエンティティ
        Entity input = new Entity();

        public ProgramSelector()
        {

        }

        public void Draw(GameTime gameTime)
        {
            //入力のエンティティの位置を設定。ボトムから-15ピクセル移動した部分。
            //画面中央の位置からYの要素を2倍してボトムの位置を取得している。
            input.SetPosition(new Vector2(0, (Game1.GetInstance().GetCenter().Y * 2) - 15));
        }

        public void Initialize()
        {

        }

        public void Start()
        {
            //メッセージ描画
            messageRender = message.AddComponent(new TextRender(message, 1, "プログラムの名前を入力してください。", Color.White)) as TextRender;
            //入力文字の描画
            inputTextRender = input.AddComponent(new TextRender(input, 1, "", Color.White)) as TextRender;
            //キーボードシステムの初期化
            keyboardSystem = new KeyboardSystem(inputTextRender);
        }
        public void Update(GameTime gameTime)
        {
            bool isShift = false;
            //オート起動システムが起動しているならば
            if(autoGameLaunch)
            {
                //自動で指定のゲームを名前から起動。

                foreach (GameProgramInfo programInfo in Game1.GetInstance().GetProgramManager().GetProgramList())
                {
                    //自動起動のターゲットの名前を一致したら
                    if(programInfo.GetName() == autoGameLaunchTarget)
                    {

                    }
                }
            }
            //キーボードシステムの更新処理
            keyboardSystem.Update(gameTime);
            //エンターキーが押された場合、プログラムをロードする処理へ移動。
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                LoadProgram();
            }
            //何も入力されていない場合
            if (inputTextRender.GetText() == "")
            {
                //プログラムの名前
                string text = "プログラムの名前を入力してください。\n";
                //プログラムの一覧を描画
                SetProgramListString(text, messageRender);
            }
            else
            {
                string text = "見つかったプログラム\n";
                //プログラムの一覧を描画
                SetProgramListString(text,messageRender);
            }
        }
        //プログラム一覧をstringに代入する。
        private void SetProgramListString(string text,TextRender render)
        {
            //ゲームプログラムのリストを取得
            foreach (GameProgramInfo programInfo in Game1.GetInstance().GetProgramManager().GetProgramList())
            {
                //入力された文字列から候補を選択してそれのみ表示されるようにする。
                //プログラムの名前を取得して、入力有れている文字が含まれているか確認
                if (programInfo.GetName().Contains(inputTextRender.GetText()))
                {
                    //プログラム一覧の設定
                    //--表示の例--
                    //名前　バージョン
                    text += programInfo.GetName() + "　" + programInfo.GetVersion() + "\n";
                }
            }
            //レンダーの
            render.SetText(text);
        }
        private void LoadProgram()
        {
            //プログラムの名前をキーボード入力から取得
            string programName = inputTextRender.GetText();
            //見つかったかのフラグ
            bool found = false;
            //ゲームプログラムのリストを取得
            foreach (GameProgramInfo programInfo in Game1.GetInstance().GetProgramManager().GetProgramList())
            {
                //プログラムの名前が一致するなら
                if (programName == programInfo.GetName())
                {
                    //選択されたゲームを登録
                    Game1.GetInstance().RegisterGame(programInfo.GetGame());
                    //見つかったかのフラグをオンにする。
                    found = true;
                }
            }
            //プログラムが見つからなかった場合
            if(found == false)
            {
                //プログラムが見つからなかったと表示。
                messageRender.SetText("プログラムが見つかりませんでした。");
            }
        }
        //全コンポーネントを取得
        List<Component> GameBase.GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { message, input });
        }
        public void Dispose()
        {

        }
    }
}
