using System;
using System.Collections;
using UnityEngine;

public class Sequence : MonoBehaviour
{
	[SerializeField] public GUISkin skin;
	[SerializeField] public Scene CurrentScene = null;
	[SerializeField] public Scene PrevScene = null;
	public void Start()
	{
		CurrentScene = new Boot ();
		PrevScene = CurrentScene;
		StartCoroutine(Coroutine());

		string fileName = "TestStage"; // not .jso
		Debug.Log ("Json/" + fileName);
		TextAsset txt = Instantiate(Resources.Load ("Json/" + fileName)) as TextAsset;
		Json.MapData.Header header = LitJson.JsonMapper.ToObject<Json.MapData.Header>(txt.text);
		Debug.Log ("height : " + header.height);
	}
	 private IEnumerator Coroutine()
	{
		for (;;) 
		{
			CurrentScene.Initialize();
			CurrentScene.RequestLoad();
			do
			{
				yield return null;
			} while (CurrentScene.IsLoad()== false );

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
			GC.Collect();
		}
	}
	public void OnGUI () 
	{
		GUI.skin = skin;
		CurrentScene.DebugDraw(0.0f, 0.0f);
	}
}
