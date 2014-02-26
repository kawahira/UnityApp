using System;
using System.Collections;
using UnityEngine;

public class Sequence : MonoBehaviour
{
	[SerializeField]  GUISkin skin;
	[SerializeField]  Scene CurrentScene = null;
	[SerializeField]  Scene PrevScene = null;
	void Start()
	{
		CurrentScene = new Title ();
		PrevScene = CurrentScene;
		StartCoroutine(Coroutine());
	}
	IEnumerator Coroutine()
	{
		for (;;) 
		{
			CurrentScene.Initialize();
			CurrentScene.RequestLoad();
			do
			{
				yield return null;
			} while (CurrentScene.isLoad()== false );

			CurrentScene.RequestStart();
			do
			{
				if ( CurrentScene.isDone() )
				{
					break;
				}
				yield return null;
			} while ( true );
			CurrentScene.RequestUnload();
			do
			{
				if ( CurrentScene.isUnload() )
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
		}
	}
	public void OnGUI () 
	{
		GUI.skin = skin;
		CurrentScene.DebugDraw(0.0f, 0.0f);
	}
}
