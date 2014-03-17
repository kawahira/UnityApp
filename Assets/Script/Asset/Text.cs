// <copyright file="Text.cs" >(C)2014</copyright>
using System;
using System.Collections;
using UnityEngine;

namespace Asset
{
	public class Text : BlockMultiThread
	{
		private System.Action<string> callback = null;
		private string body = string.Empty;
		public Text(string url,int group,int id,int version,System.Action<string> cb) : base(url,null,group,id,version)
        {
            callback = cb;
        }
		public override IEnumerator Read()
		{
			do
			{
				// アンマネージ リソースアクセスクラスへのアクセスにはusing (Dispose保証)
				using(WWW www = new WWW (url))
				{
					while(!www.isDone)
					{
						progress = www.progress;
						yield return null;
					}
					// wwwはファイルが存在しないなどのケースでもisDoneにtrueが返ってくるのでエラー対処はerrorのみで頼る
					if (www.error != null)
					{
						Debug.Log("WWWダウンロードにエラーがありました:" + www.error);
						yield return null;	// www no error de 1frame de kaette kurumono ga arutame
					}
					else
					{
						readFlag = true;
						body 	 = www.text;
					}
				}
			} while(readFlag == false);
		}
		public override void Resolve()
		{
			if ( callback != null )
			{
				callback(body);
				callbackFlag = true;
			}
		}
	}
}

