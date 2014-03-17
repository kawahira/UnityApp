// <copyright file="Scene.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Scene
{
	private int count;
	public virtual void Initialize()
	{
		Debug.Log(GetType().Name);
		count = 0;
	}
	public virtual void RequestLoad(ref List<Asset.Block> blocks)
	{
	}
	public virtual void RequestStart()
	{
	}
	public virtual void RequestUnload()
	{
	}
	public virtual bool IsLoad()
	{
		++count;
		return count > 600 ? true : false;
	}
	public virtual bool IsDone()
	{
		return true;
	}
	public virtual bool IsUnload()
	{
		return true;
	}
	public virtual Scene GetNext()
	{
		return null;
	}
	public virtual void DebugDraw(float x, float y)
	{
		StringBuilder text = new StringBuilder ();
		text.Append ("Scene : " + GetType().Name + "\n");
		text.Append ("Count : " + count.ToString ("0") + "\n");
		GUI.Box (new Rect (5,300,310,100),string.Empty);
		GUI.Label (new Rect (10,305,1000,200),text.ToString ());
	}
}

