//-------------------------------------------------------------------------------------------------
// F12キーでゲーム画面のスクリーンショットを作成するスクリプト
// 画像サイズはUnityエディタのゲームビューのアスペクト比をStandalonにすることで、そのサイズで保存される
// Starndalonのサイズ変更はビルドセッティング→プレーヤーセッティングから
//-------------------------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEditor;

public class CapturController : MonoBehaviour
{
    string absolutePath = "C:/Users/user/Desktop";      // 保存するフォルダパス
    string gameTitle = "GameTitle";                     // 画像ファイル名

    void Update()
    {
        // F12キーでゲーム画面のスクリーンショットを作成＆保存
        if(Input.GetKeyDown(KeyCode.F12))
        {
            // 保存場所を指定
            //absolutePath = EditorUtility.SaveFolderPanel("Save screenshot png", absolutePath, "");

            // タイムスタンプを付けたファイル名を作成
            string fileName = absolutePath + "/" + gameTitle + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

            // png形式でスクリーンショットを作成
            // 絶対パス（absolutePath）が空の場合はプロジェクトのルートフォルダに保存される
            ScreenCapture.CaptureScreenshot(fileName);

            // メッセージボックスを出す
            // EditorUtility.DisplayDialog("スクリーンショットを保存しました。", fileName, "OK");
        }

        // F11キーでスクリーンショットを保存したファイルを開く
        if(Input.GetKeyDown(KeyCode.F11))
        {
            // 指定フォルダをエクスプローラーで開く
            System.Diagnostics.Process.Start(absolutePath);
        }

    }
}
