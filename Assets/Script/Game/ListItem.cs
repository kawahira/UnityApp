using System;
using System.Collections.Generic;
using UnityEngine;

public class ScrollList
{
	public List<ScrollPairData>	pairData = new List<ScrollPairData>();
	public Vector2			position;
	public int				selctedIndex = -1;
	public void Add(string key, string value)
	{
		pairData.Add (new ScrollPairData(key,value));
	}
	public void Update(float delta)
	{
		for ( int i = 0 ; i < pairData.Count ; ++i )
		{
			pairData[i].Update(delta);
		}
	}
	public void Selected(int index)
	{
		if ( selctedIndex != index )
		{
			if ( index < pairData.Count )
			{
				selctedIndex = index;
				pairData[selctedIndex].Focused();
			}
		}
	}
}

public class ScrollPairData
{
	public string title;
	public string help;
	public float  animationAlpha;
	public ScrollList chield;
	public ScrollPairData(string key, string value)
	{
		title			= key;
		help			= value;
		animationAlpha	= 0.0f;
		chield			= null;
	}
	public void Update(float delta)
	{
		animationAlpha -= delta;
		if ( animationAlpha < 0.0f )
		{
			animationAlpha = 0.0f;
		}
	}
	public void Focused()
	{
		animationAlpha = 1.0f;
	}
}

