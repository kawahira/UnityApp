using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

public class Title : Scene
{
	private Vector2 scrollPosition;
	private List<ListItem> list = new List<ListItem>();  
 	public Title()
	{
		list.Add (new ListItem("title1","help1"));
		list.Add (new ListItem("title2","help2"));
		list.Add (new ListItem("title3","help3"));
	}
	public override void DebugDraw(float x, float y)
	{
		float emSizeScale = 96.0f / 72.0f;
		float fontHeight  = GUI.skin.label.fontSize;
		float fontWidth   = fontHeight * 12.0f;	// magic number.
		float titleHeight = (fontHeight / 1.0f) * emSizeScale; 
		float helpHeight  = (fontHeight / 2.0f) * emSizeScale;
		Debug.Log (GUI.skin.label.fontSize.ToString());
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (200), GUILayout.Height (600));

 		for ( int i = 0 ; i < list.Count ; ++i )
		{
			GUI.skin.label.fontSize = (int)titleHeight;
			GUI.Label(new Rect(x,y,fontWidth,titleHeight),list[i].Title);
			y+=titleHeight;
			GUI.skin.label.fontSize = (int)helpHeight;
			GUI.Label(new Rect(x,y,fontWidth,helpHeight),list[i].Help);
			y+=helpHeight;
		}
		GUI.EndScrollView(); 
		GUI.skin.label.fontSize = (int)fontHeight;
	}
	public override Scene GetNext()
	{
		return null;
	}
}

