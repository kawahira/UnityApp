using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Title : Scene
{
	[SerializeField] public Vector2 scrollPosition;
	private List<ListItem> list = new List<ListItem>();  
 	public Title()
	{
		list.Add (new ListItem("Scene"," "));
		list.Add (new ListItem("title2","help2"));
		list.Add (new ListItem("title3","help3"));
	}
	public override void DebugDraw(float x, float y)
	{
		float xpos = x;
		float ypos = y;
		int backupFontSize = GUI.skin.label.fontSize;
		float emSizeScale = 96.0f / 72.0f;
		float fontHeight  = (float)GUI.skin.label.fontSize * emSizeScale;
		float fontWidth   = fontHeight * 12.0f;	// magic number.
		float titleHeight = fontHeight; 
		float helpHeight  = fontHeight / 4.0f;
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (200), GUILayout.Height (200));

 		for ( int i = 0 ; i < list.Count ; ++i )
		{
			GUI.skin.label.fontSize = (int)titleHeight;
			GUI.skin.label.fontStyle = FontStyle.Bold;
			GUI.Label(new Rect(xpos,ypos,fontWidth,titleHeight),list[i].Title);
			ypos+=titleHeight;
			GUI.skin.label.fontSize = (int)helpHeight;
			GUI.skin.label.fontStyle = FontStyle.Normal;
			GUI.Label(new Rect(xpos,ypos,fontWidth,helpHeight),list[i].Help);
			ypos+=helpHeight;
		}
		GUI.EndScrollView(); 
		GUI.skin.label.fontSize = backupFontSize;
	}
	public override Scene GetNext()
	{
		return null;
	}
}

