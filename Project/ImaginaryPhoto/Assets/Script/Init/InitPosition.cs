using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 場所を同期するスクリプト
 */
public class InitPosition: MonoBehaviour 
{
	// 保存するポジション
	[SerializeField]
	private Transform TargetTransform;

	// Use this for initialization
	void Awake () 
	{
		// シーン切り替え削除されないように設定
		DontDestroyOnLoad(this.gameObject);
	}	

	void Start()
	{
		this.gameObject.transform.position = TargetTransform.position;
		this.gameObject.transform.rotation = TargetTransform.rotation;
	}
}
