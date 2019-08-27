using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * 同期用のパラメータのJsonを扱うクラス
 */
public static class TransformJsonControle {

	//  同期する情報の構造を作成する
	[Serializable]
	public class Pram
	{
		public string Name;
		public Vector3 Position;
		public Quaternion Rotation;
	}

	// シリアライズ関数
	public static string JsonSerialize( Transform syncTransform ){
		// パラメータを詰める
		Pram tmp = new Pram ();
		tmp.Name = "Chara";
		tmp.Position = syncTransform.position;
		tmp.Rotation = syncTransform.rotation;

		// json形式で返却
		return JsonUtility.ToJson (tmp);
	}

	// ディシアライズ関数
	public static Pram JsonDeserialize( string syncTransform ){
		// json形式で返却
		return JsonUtility.FromJson<Pram>(syncTransform);
	}
}
