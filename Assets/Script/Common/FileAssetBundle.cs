﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;	// needs OnGUI
using UnityEngine;

//s/xbm7pgfze2s5kta/Boot.json
//https://dl.dropboxusercontent.com/u/86805032/TileA.unity3d
//https://dl.dropboxusercontent.com/u/86805032/TileAll.unity3d
public class FileAssetBundle : MonoBehaviour 
{
	public List<Asset.Block>	blockList = new List<Asset.Block>();
	private void callbackTest(string str)
	{
//		Json.MapData.Header header = LitJson.JsonMapper.ToObject<Json.MapData.Header>(str);
//		Debug.Log (header); 
	}
	private void InstantiateCallback(List<object> objects,SerializeData.FileList files)
	{
	}
	void Start() 
 	{
		Caching.CleanCache();
		//		blockList.Add(new Asset.Bundle(mapChipBaseURL, MapChipName , 0, 0, 1, InstantiateCallback));
		StartCoroutine (ActiveEntry());
	}
	public List<Asset.Block> GetBlock()
	{
		return blockList;
	}
	IEnumerator Action(Asset.Block block)
	{
		yield return StartCoroutine(block.Read());	
 		yield return StartCoroutine(block.Callback());
	}
	IEnumerator ActiveEntry ()
	{
		// キャッシュシステムの準備が完了するのを待つ (稼働中に状態が変わらない前提)
		while (!Caching.ready) { yield return null; }
		for ( ;; )
		{
			Asset.Block result = blockList.Find( delegate(Asset.Block block) { return block.isRead() == false; });
			yield return result == null ? null : StartCoroutine(Action(result)); 
			if ( result != null )
			{
				if ( result.isAutoRemoved() )
				{
					blockList.Remove(result);
				}
			}
		}
	}
	void OnGUI()
	{
		StringBuilder text = new StringBuilder ();
		text.Append ("Blocks : " + blockList.Count);
 		GUI.Box (new Rect (5,300,310,100),string.Empty);
		GUI.Label (new Rect (10,305,1000,200),text.ToString ());
	}
}