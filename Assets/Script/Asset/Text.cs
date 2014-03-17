// <copyright file="Text.cs" >(C)2014</copyright>
using System;
using System.Collections;
using UnityEngine;

namespace Asset
{
		// <summary>
		// AssetTextのBlock処理 </summary>
		public class Text : BlockMultiThread
		{
				private System.Action<string> callback = null;
				private string body = string.Empty;
				// <summary>
				// コンストラクタ </summary>
				public Text (string url, int group, int id, int version, System.Action<string> cb) : base (url, null, group, id, version)
				{
						callback = cb;
				}
				// <summary>
				// 読み込み処理 </summary>
				public override IEnumerator Read ()
				{
						do {
								// アンマネージ リソースアクセスクラスへのアクセスにはusing (Dispose保証)
								using (WWW www = new WWW (url)) {
										while (!www.isDone) {
												progress = www.progress;
												yield return null;
										}
										// wwwはファイルが存在しないなどのケースでもisDoneにtrueが返ってくるのでエラー対処はerrorのみで頼る
										if (www.error != null) {
												Debug.Log ("WWWダウンロードにエラーがありました:" + www.error);
												yield return null;	// www no error de 1frame de kaette kurumono ga arutame
										} else {
												readFlag = true;
												body = www.text;
										}
								}
						} while(readFlag == false);
				}
				// <summary>
				// 参照解決 </summary>
				public override void Resolve ()
				{
						if (callback != null) {
								callback (body);
								callbackFlag = true;
						}
				}
		}
}

