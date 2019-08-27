using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ImaginaryPhotoのシーンを管理するクラス
 */
public class Manager : MonoBehaviour 
{
	// シリアル通信
	[SerializeField]
	private SerialHandler SerialHandler;

	// 写真保存
	[SerializeField]
	private SaveRenderTexture SavePhoto;

	// Use this for initialization
	void Start () 
	{
		SerialHandler.OnDataReceived += OnDataReceivedMessage;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//受信した信号(message)に対する処理
	void OnDataReceivedMessage(string receiveMessage)
	{
		// ボタンを押した時の動き
		if(receiveMessage.Contains("Push"))
		{
			StartCoroutine (SavePhoto.SavePng ());
			receiveMessage = null;
		}
	}
}
