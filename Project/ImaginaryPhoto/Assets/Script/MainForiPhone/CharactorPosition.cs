using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * キャラクターのポジションを取得
 */
public class CharactorPosition : MonoBehaviour 
{
	// プレイヤーの位置
	[SerializeField]
	private Transform PlayerPositon;

	// Update is called once per frame
	void Update () 
	{
        // カメラの横の場所にいるように設定
        this.gameObject.transform.position = new Vector3(PlayerPositon.position.x + 1.5f,PlayerPositon.position.y,PlayerPositon.position.z);
	}
}
