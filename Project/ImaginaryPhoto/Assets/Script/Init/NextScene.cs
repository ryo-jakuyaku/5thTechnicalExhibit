using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * シーンを切り替える
 */
public class NextScene : MonoBehaviour 
{
	// 次のシーン名
	private string NextSceneName;

	// Use this for initialization
	void Start () 
	{
#if UNITY_EDITOR
		NextSceneName = "MainForPC";
#elif UNITY_IPHONE
		NextSceneName = "MainForiPhone";
#endif
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKey)
		{
			SceneManager.LoadScene (NextSceneName);
		}
	}
}
