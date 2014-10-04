// <copyright file="DeltaTime.cs" >(C)2014</copyright>
using System.Collections;
using UnityEngine;

/// <summary>
/// 時間管理 </summary>
public class DeltaTime
{
		private static volatile DeltaTime instance;
		private static object syncRoot = new Object ();

		/// <summary>
		/// シングルトン取得 </summary>
		public static DeltaTime Instance {
				get {
						if (instance == null) {
								lock (syncRoot) {
										if (instance == null)
												instance = new DeltaTime ();
								}
						}
						return instance;
				}
		}

//		private int targetFrameRate;
//		private float delta;
		private float scale = 1.0f;
		private float base60FrameDelta = 60.0f;

		/// <summary>
		/// スケール値 </summary>
		public float GetScale ()
		{
				return (Time.deltaTime * base60FrameDelta) * scale;
		}

		/// <summary>
		/// 経過時間の取得 </summary>
		public float Get ()
		{
				return Time.deltaTime;
		}
	public float GetFrame ()
	{
		return Time.deltaTime * base60FrameDelta;
	}
}
