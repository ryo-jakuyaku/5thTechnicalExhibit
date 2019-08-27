using System.Collections;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Net;

/*
 * PC側のWebSocketのクラス
 */
public class WebSocketPCSide : MonoBehaviour 
{
	// 接続サーバURL
    private string URL = "ws://localhost:";

	// ポート番号
	private int Port = 8000;

	// ウェブソケットサーバー
	private WebSocket Socket;

	// 架空のキャラクターのPrefab
	public GameObject PartnerCharactor;

	// パラメータ
	private TransformJsonControle.Pram CharactorTransformPram;

	// 接続されたかどうか
	private bool IsiPhoneConnect = false;

	// 作成したかどうか
	private bool isCharactorCreate = false;

	// 一緒に写真を取るキャラクターの位置
	private Transform CharactorTransform;

	// Use this for initialization
	void Start()
	{
        /// 初期化
        CharactorTransformPram = new TransformJsonControle.Pram();

		// WebSocketを生成
		Socket = new WebSocket(URL + Port.ToString() + "/");

		Socket.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

        Socket.OnMessage += (sender, e) =>
		{
            Debug.Log("Receive is " + e.Data);

			// 作成をキック
            if(e.Data.ToString().Contains("Connect")){
				IsiPhoneConnect = true;
			}
				
			// データが送信されてきたらパース
            CharactorTransformPram = TransformJsonControle.JsonDeserialize (e.Data);
		};
		
		Socket.OnError += (sender, e) =>
		{
			Debug.Log("WebSocket Error Message: " + e.Message);
		};

		Socket.OnClose += (sender, e) =>
		{
			Debug.Log("WebSocket Close");
		};

		// 接続開始
		Socket.Connect();

        // 接続開始
        Socket.Send("Connect Check");
	}

	void Update()
	{
        if(IsiPhoneConnect)
        {
            // 表示していなければ表示
            if(!PartnerCharactor.activeSelf)
            {
                // iPhone側が接続されたらキャラを作成
                PartnerCharactor.SetActive(true);
            }

            // 座標を同期(x座標のみ反転してみる)
            PartnerCharactor.transform.position = new Vector3( -CharactorTransformPram.Position.x, CharactorTransformPram.Position.y, CharactorTransformPram.Position.z);
            PartnerCharactor.transform.rotation = CharactorTransformPram.Rotation;
        }		
	}

    // 実行終了前にソケットを閉じる
    void OnDestroy()
    {
        // ソケットを閉じてメモリ解放
        Socket.Close();
        Socket = null;
    }
}
