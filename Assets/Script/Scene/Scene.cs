using UnityEngine;
using System;
using System.Text;

public class Scene
{
	int count;
	public virtual void Initialize()
	{
		Debug.Log(GetType().Name);
		count = 0;
	}
	public virtual void RequestLoad()
	{
	}
	public virtual void RequestStart()
	{
	}
	public virtual void RequestUnload()
	{
	}
	public virtual bool isLoad()
	{
		++count;
		return count > 60000 ? true : false;
	}
	public virtual bool isDone()
	{
		return true;
	}
	public virtual bool isUnload()
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
		text.Append ("Count : " + (count).ToString ("0") + "\n");
		GUI.Box (new Rect (5,300,310,100),"");
		GUI.Label (new Rect (10,305,1000,200),text.ToString ());
	}
}

