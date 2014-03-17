// <copyright file="Title.cs" >(C)2014</copyright>
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
			scrollList.pairData.Add (new ScrollPairData("title" + i.ToString(),"help" + i.ToString()));
		}
	}
	public override void DebugDraw(float x, float y)
	{
		int backupFontSize 	= GUI.skin.label.fontSize;
		float xpos 			= x;
		float ypos 			= y;
		float emsize 		= 96.0f / 72.0f;
 		float fontHeight  	= (float)GUI.skin.label.fontSize * emsize;
		float fontWidth   	= fontHeight * 12.0f;	// magic number.
		float titleHeight 	= fontHeight; 
		float helpHeight  	= fontHeight / 4.0f;
		float totalHeight 	= (titleHeight + helpHeight) * scrollList.pairData.Count;
		
		scrollList.position = GUI.BeginScrollView (new Rect(0,0,Screen.width,Screen.height),scrollList.position,new Rect(0,0,Screen.width,totalHeight));
		scrollList.pairData.ForEach(delegate(ScrollPairData pair)
		{
			if ( GUI.Button(new Rect (xpos,ypos,fontWidth,titleHeight + helpHeight),string.Empty) )
			{
				pair.Focused();
			}
			GUI.skin.label.fontSize = (int)titleHeight;
			GUI.skin.label.fontStyle = FontStyle.Bold;
			if ( pair.animationAlpha != 0.0f )
			{
				GUI.backgroundColor = new Color (1.0f,1.0f,1.0f,pair.animationAlpha);
				GUI.Box(new Rect (xpos,ypos,fontWidth,titleHeight + helpHeight),string.Empty);
			}
			GUI.Label(new Rect(xpos,ypos,fontWidth,titleHeight),pair.title);
			ypos+=titleHeight;
			GUI.skin.label.fontSize = (int)helpHeight;
			GUI.skin.label.fontStyle = FontStyle.Normal;
			GUI.Label(new Rect(xpos,ypos,fontWidth,helpHeight),pair.help);
			ypos+=helpHeight;
			pair.Update(DeltaTime.Instance.Get());
		} );
		GUI.EndScrollView();
		GUI.skin.label.fontSize = backupFontSize;
	}
	public override Scene GetNext()
	{
		return null;
	}
}

