using System.Collections;
using UnityEngine;

public class DeltaTime
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
	private int targetFrameRate;
	private float delta;
	private float scale = 1.0f;
	private float base60FrameDelta = 1.0f / 60.0f;
	public float GetScale() { return (Time.deltaTime / base60FrameDelta) * scale; }
}
