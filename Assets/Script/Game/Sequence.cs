using System;
using System.Collections;
using UnityEngine;

using System.Collections.Generic;	// json test用

[System.Serializable]
public class mapDataJsonLayer
{
	public List<int> data;
	public int height;
	public string name;
	public int opacity;
	public string type;
	public bool visible;
	public int width;
	public int x;
	public int y;
}

[System.Serializable]
public class mapDataTerrains
{
	public string name;
	public int tile;
}
[System.Serializable]
public class mapDataTilesets
{
	public int firstgid;
	public string image;
	public int imageheight;
	public int imagewidth;
	public int margin;
	public string name;
	public List<string> properties;
	public int spacing;
	public List<mapDataTerrains> terrains;
	public int tileheight;
	public int tilewidth;
}

[System.Serializable]
public class mapDataJson
{
	public int height;
	public List<mapDataJsonLayer> layers;
	public string orientation;
	public List<string> properties;
	public int tileheight;
	public List<mapDataTilesets> tilesets;
	public int tilewidth;
	public int version;
	public int width;
}

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
		mapDataJson data = LitJson.JsonMapper.ToObject<mapDataJson>(txt.text);
				Debug.Log ("height : " + data.height);
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
