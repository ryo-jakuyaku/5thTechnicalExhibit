using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * シリアルハンドラーのデバッグ用のスクリプト
 */
public class SerialDebug : MonoBehaviour 
{
	[SerializeField]
	private SerialHandler SerialHandler;

	// Use this for initialization
	void Start () 
	{
		SerialHandler.OnDataReceived += OnDataReceivedMessage;
	}

	//受信した信号(message)に対する処理
	void OnDataReceivedMessage(string receiveMessage)
	{
		// ボタンを押した時の動き
		if(receiveMessage.Contains("Push"))
		{
			Debug.Log ("ok");
			receiveMessage = null;
		}
	}
}
