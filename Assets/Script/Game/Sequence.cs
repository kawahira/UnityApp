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
	[SerializeField] public Scene CurrentScene = null;
	[SerializeField] public Scene PrevScene = null;
	Dictionary<string, Scene> SceneDictionary = new Dictionary<string, Scene>();
	/// <summary>
	/// Start
	/// </summary>
	public void Start()
	{
		SceneDictionary.Add("Boot"	,new Boot());
		SceneDictionary.Add("Title"	,new Title());

		CurrentScene = (Scene)Activator.CreateInstance(SceneDictionary["Boot"].GetType());
		PrevScene = CurrentScene;
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
			CurrentScene.Initialize();
			CurrentScene.RequestLoad(ref GetComponent<FileAssetBundle>().blockList);
			do
			{
				yield return null;
			} while ( GetComponent<FileAssetBundle>().blockList.Find( delegate(Asset.Block block) { return block.isRead() == false; }) != null  );
			
			CurrentScene.RequestStart();
			do
			{
				if ( CurrentScene.IsDone() )
				{
					break;
				}
				yield return null;
			} while ( true );
			CurrentScene.RequestUnload();
			do
			{
				if ( CurrentScene.IsUnload() )
				{
					break;
				}
				yield return null;
			} while ( true );
			{
				Scene scene = CurrentScene.GetNext();
				if ( scene == null )
				{
					CurrentScene = (Scene)Activator.CreateInstance(PrevScene.GetType());
				}
				else
				{
					PrevScene = CurrentScene;
					CurrentScene = scene;
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
