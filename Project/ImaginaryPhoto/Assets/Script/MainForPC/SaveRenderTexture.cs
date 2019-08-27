using System.Collections;
using UnityEngine;
using System.IO;

/*
 * Render textureを保存するクラス
 */
public class SaveRenderTexture : MonoBehaviour {

    // 保存したいレンダーテクスチャー
    private RenderTexture TargetRenderTexture;

    // Render Texture用のカメラ
	[SerializeField]
    private Camera RenderCamera;

    private bool IsSaved;

    private void Start()
    {
        // 初期化
        TargetRenderTexture = RenderCamera.targetTexture;
        IsSaved = false;
    }

	private void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine (SavePng());
		}
    }

    // Texture2DからPNG画像を生成
    public IEnumerator SavePng()
    {
        if (IsSaved)
        {
            yield break;
        }
        IsSaved = true;

        Texture2D tex = new Texture2D(TargetRenderTexture.width, TargetRenderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = TargetRenderTexture;
        tex.ReadPixels(new Rect(0, 0, TargetRenderTexture.width, TargetRenderTexture.height), 0, 0);
        tex.Apply();

        // PNG変換
        byte[] bytes = tex.EncodeToPNG();

        // メモリ開放
        Destroy(tex);

		File.WriteAllBytes( Application.dataPath + "/test.png", bytes);

        yield return null;

		Debug.Log ("Saved");
	}
}

