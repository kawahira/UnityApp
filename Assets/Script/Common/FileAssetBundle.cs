// <copyright file="FileAssetBundle.cs" >(C)2014</copyright>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

	// needs OnGUI
using UnityEngine;

//s/xbm7pgfze2s5kta/Boot.json
//https://dl.dropboxusercontent.com/u/86805032/TileA.unity3d
//https://dl.dropboxusercontent.com/u/86805032/TileAll.unity3d
public class FileAssetBundle : MonoBehaviour
{
		public List<Asset.Block>	blockList = new List<Asset.Block> ();

		private void CallbackTest (string str)
		{
//		Json.MapData.Header header = LitJson.JsonMapper.ToObject<Json.MapData.Header>(str);
//		Debug.Log (header); 
		}

		private void InstantiateCallback (List<object> objects, SerializeData.FileList files)
		{
		}

		public void Start ()
		{
				Caching.CleanCache ();
				StartCoroutine (ActiveEntry ());
		}

		public List<Asset.Block> GetBlock ()
		{
				return blockList;
		}

		private IEnumerator Action (Asset.Block block)
		{
				yield return StartCoroutine (block.Read ());	
				yield return StartCoroutine (block.Callback ());
		}

		private IEnumerator ActiveEntry ()
		{
				// キャッシュシステムの準備が完了するのを待つ (稼働中に状態が変わらない前提)
				while (!Caching.ready) {
						yield return null;
				}
				for (;;) {
						Asset.Block result = blockList.Find (delegate(Asset.Block block) {
								return block.IsRead () == false;
						});
						yield return result == null ? null : StartCoroutine (Action (result)); 
						if (result != null) {
								if (result.IsAutoRemoved ()) {
										blockList.Remove (result);
								}
						}
				}
		}

		public void OnGUI ()
		{
				StringBuilder text = new StringBuilder ();
				text.Append ("Blocks : " + blockList.Count + "\n");
				int count = 0;
				blockList.ForEach(delegate(Asset.Block block)
				{
						text.Append("[" + count + "]:" + block.url + "Prog:" + block.GetProgress() + "\n");
						count ++;
				});
						text.Append("height:" + Screen.height + "  width:" + Screen.width + "\n");
				
				GUI.Box   (new Rect ( 0, Screen.height-100, Screen.width, Screen.height), string.Empty);
				GUI.Label (new Rect ( 0, Screen.height-100, Screen.width, Screen.height), text.ToString ());
		}
}
