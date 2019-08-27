using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;
using WebSocketSharp.Net;

/*
 * iPhone側のWebsocketサーバー
 */
public class WebSocketiPhoneSide : MonoBehaviour 
{
	// 接続サーバURL
	private string URL = "ws://192.168.11.176:";

	// ポート番号
	private int Port = 4000;

	// ウェブソケットサーバー
	private WebSocket Socket;

	// 一緒に写真を取るキャラクターの位置
	public Transform CharactorTransform;

	// Use this for initialization
	void Start()
	{
		// WebSocketを生成
		Socket = new WebSocket (URL + Port.ToString () + "/");

		Socket.OnOpen += (sender, e) => {
			Debug.Log ("WebSocket Open");
		};

		Socket.OnMessage += (sender, e) => {
			Debug.Log ("Data: " + e.Data);
		};

		Socket.OnError += (sender, e) => {
			Debug.Log ("WebSocket Error Message: " + e.Message);
		};

		Socket.OnClose += (sender, e) => {
			Debug.Log ("WebSocket Close");
		};

		// 接続開始
		Socket.Connect ();
	}
	
	void Update()
	{
		// PC側にキャラクターの位置を通知
        Socket.Send(TransformJsonControle.JsonSerialize(CharactorTransform));
	}

    // 実行終了前にソケットを閉じる
    void OnDestroy()
    {
        // ソケットを閉じてメモリ解放
        Socket.Close();
        Socket = null;
    }
}
