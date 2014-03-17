// <copyright file="Sequence.cs" >(C)2014</copyright>
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーケンス管理処理
/// </summary>
public class Sequence : MonoBehaviour
{
	[SerializeField] public GUISkin skin;
	[SerializeField] public Scene currentScene = null;
	[SerializeField] public Scene prevScene = null;
	private Dictionary<string, Scene> sceneDictionary = new Dictionary<string, Scene>();
	/// <summary>
	/// Start
	/// </summary>
	public void Start()
	{
		sceneDictionary.Add("Boot"	,new Boot());
		sceneDictionary.Add("Title"	,new Title());

		currentScene = (Scene)Activator.CreateInstance(sceneDictionary["Boot"].GetType());
		prevScene = currentScene;
		StartCoroutine(Coroutine());
/*
		WWW www = new WWW("file://Json/TestStageaa");
		Debug.Log("err:" + www.error );
		string fileName = "TestStage";
		Debug.Log ("Json/" + fileName);
		TextAsset txt = Instantiate(Resources.Load ("Json/" + fileName)) as TextAsset;
		Json.MapData.Header header = LitJson.JsonMapper.ToObject<Json.MapData.Header>(txt.text);
		Debug.Log ("height : " + header.height);
*/
	}
	/// <summary>
	/// シーケンス実体
	/// </summary>
	 private IEnumerator Coroutine()
	{
		for (;;) 
		{
			currentScene.Initialize();
			currentScene.RequestLoad(ref GetComponent<FileAssetBundle>().blockList);
			do
			{
				yield return null;
			} while ( GetComponent<FileAssetBundle>().blockList.Find( delegate(Asset.Block block) { return block.IsRead() == false; }) != null  );
			
			currentScene.RequestStart();
			do
			{
				if ( currentScene.IsDone() )
				{
					break;
				}
				yield return null;
			} while ( true );
			currentScene.RequestUnload();
			do
			{
				if ( currentScene.IsUnload() )
				{
					break;
				}
				yield return null;
			} while ( true );
			{
				Scene scene = currentScene.GetNext();
				if ( scene == null )
				{
					currentScene = (Scene)Activator.CreateInstance(prevScene.GetType());
				}
				else
				{
					prevScene = currentScene;
					currentScene = scene;
				}
			}
			Resources.UnloadUnusedAssets(); 
			GC.Collect();
		}
	}
	/// <summary>
	/// シーンの On GUI（本来はあってはいけない）
	/// </summary>
	public void OnGUI () 
	{
		GUI.skin = skin;
//		CurrentScene.DebugDraw(0.0f, 0.0f);
	}
}
