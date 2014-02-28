using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Title : Scene
{
	private ScrollList scrollList = new ScrollList();
 	public Title()
	{
		for ( int i = 0 ; i < 30 ; ++i )
		{
			scrollList.Add ("title" + i.ToString(),"help" + i.ToString());
		}
	}
	public override void DebugDraw(float x, float y)
	{
		float deltaTime = 0.001f;
		float xpos = x;
		float ypos = y;
		int backupFontSize = GUI.skin.label.fontSize;
		float emsize = 96.0f / 72.0f;
 		float fontHeight  = (float)GUI.skin.label.fontSize * emsize;
		float fontWidth   = fontHeight * 12.0f;	// magic number.
		float titleHeight = fontHeight; 
		float helpHeight  = fontHeight / 4.0f;
		float totalHeight = (titleHeight + helpHeight) * 30;
		
		scrollList.position = GUI.BeginScrollView (new Rect(0,0,Screen.width,Screen.height),scrollList.position,new Rect(0,0,Screen.width,totalHeight));
		// update
		for ( int i = 0 ; i < scrollList.pairData.Count ; ++i )
		{
			if ( GUI.Button(new Rect (xpos,ypos + (( titleHeight + helpHeight ) * i ),fontWidth,titleHeight + helpHeight),string.Empty) )
			{
				scrollList.Selected(i);
				break;
			}
		}

		// Draw.
		for ( int i = 0 ; i < scrollList.pairData.Count ; ++i )
		{
			GUI.skin.label.fontSize = (int)titleHeight;
			GUI.skin.label.fontStyle = FontStyle.Bold;
			if ( scrollList.pairData[i].animationAlpha != 0.0f )
			{
				GUI.backgroundColor = new Color (1,1,1,scrollList.pairData[i].animationAlpha);
				GUI.Box(new Rect (xpos,ypos,fontWidth,titleHeight + helpHeight),string.Empty);
			}
			GUI.Label(new Rect(xpos,ypos,fontWidth,titleHeight),scrollList.pairData[i].title);
			ypos+=titleHeight;
			GUI.skin.label.fontSize = (int)helpHeight;
			GUI.skin.label.fontStyle = FontStyle.Normal;
			GUI.Label(new Rect(xpos,ypos,fontWidth,helpHeight),scrollList.pairData[i].help);
			ypos+=helpHeight;
		}
		GUI.EndScrollView(); 
		GUI.skin.label.fontSize = backupFontSize;

				scrollList.Update(deltaTime); 
	}
	public override Scene GetNext()
	{
		return null;
	}
}

