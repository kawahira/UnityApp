using UnityEngine;
using System.Collections;

class DeltaTime
{
	private static volatile DeltaTime instance;
	private static object syncRoot = new Object();
	
	/// <summary>
	/// シングルトン取得
	/// </summary>
	public static DeltaTime Instance
	{
		get
		{
			if (instance == null)
			{
				lock (syncRoot)
				{
					if (instance == null)
						instance = new DeltaTime();
				}
			}
			return instance;
		}
	}
	private int TargetFrameRate;
	private float Delta;
	private float Scale = 1.0f;
	private float Base60FrameDelta = 1.0f / 60.0f;
	public float GetScale() { return (Time.deltaTime / Base60FrameDelta) * Scale; }
}
