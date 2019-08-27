using System.Collections;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Net;

/*
 * サーバーとの接続をデバッグするプログラム
 */
public class ConnectTest : MonoBehaviour {

	// WebSocketを使用するためのもの
	private WebSocket testSocket;

	// ポート番号(nodeサーバー側で設定したポート番号)
	private int portNumber = 8000;

	void Start()
	{
		// ローカルサーバでかつWebsokcetなのでws://localhost
		testSocket = new WebSocket("ws://localhost:" + portNumber + "/");

		// ソケットを開く
		testSocket.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

		// サーバー側よりメッセージが来た時のデリゲート
		testSocket.OnMessage += (sender, e) =>
		{
			Debug.Log("Receive is " + e.Data.ToString());
		};

		// エラー発生時
		testSocket.OnError += (sender, e) =>
		{
			Debug.Log("WebSocket Error Message: " + e.Message);
		};

		// ソケットを閉じる際のデリゲート
		testSocket.OnClose += (sender, e) =>
		{
			Debug.Log("WebSocket Close");
		};

		// Nodeサーバーと接続
		testSocket.Connect();

		// メッセージを送信
		testSocket.Send("Hellow Node");
	}

	// 実行終了前にソケットを閉じる
	void OnDestroy()
	{
		// ソケットを閉じてメモリ解放
		testSocket.Close();
		testSocket = null;
	}
}
