using System;
using System.Collections;
using UnityEngine;

public class Sequence : MonoBehaviour
{
	Scene CurrentScene = null;
	Scene PrevScene = null;
	void Start()
	{
		CurrentScene = new Boot ();
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
		CurrentScene.DebugDraw();
	}
}
