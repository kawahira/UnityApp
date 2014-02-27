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
		CurrentScene = new Title ();
		PrevScene = CurrentScene;
		StartCoroutine(Coroutine());
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
		}
	}
	public void OnGUI () 
	{
		GUI.skin = skin;
		CurrentScene.DebugDraw(0.0f, 0.0f);
	}
}
