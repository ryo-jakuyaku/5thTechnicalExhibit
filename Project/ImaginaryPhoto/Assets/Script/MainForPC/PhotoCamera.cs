using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * WebCameraの映像を板ポリに貼る
 */
public class PhotoCamera : MonoBehaviour {

	// お決まり
	private WebCamTexture webCameraTexture;

	// 設定用のマテリアル
	[SerializeField]
	private Material PhotoMaterial;

    void Start()
    {
		webCameraTexture = new WebCamTexture();
		PhotoMaterial.mainTexture = webCameraTexture;
		webCameraTexture.Play();
    }
}
