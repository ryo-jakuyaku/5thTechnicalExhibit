using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 前シーンのポジションを取得
 */
public class InitPositionSetting : MonoBehaviour 
{

	// 前回のシーンのTransform
	private Transform InitPositon;

	// Use this for initialization
	void Start () 
	{
		InitPositon = GameObject.Find ("InitPositon").transform;
		this.gameObject.transform.position = InitPositon.position;
	}
}
