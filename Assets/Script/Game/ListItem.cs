using System;
using System.Collections.Generic;
using UnityEngine;

public class ScrollList
{
		public List<ScrollPairData>	pairData = new List<ScrollPairData> ();
		public Vector2 position;
}

public class ScrollPairData
{
		public string title;
		public string help;
		public float animationAlpha;
		public ScrollList chield;

		public ScrollPairData (string key, string value)
		{
				title = key;
				help = value;
				animationAlpha	= 0.0f;
				chield = null;
		}

		public void Update (float delta)
		{
				animationAlpha -= delta;
				if (animationAlpha < 0.0f) {
						animationAlpha = 0.0f;
				}
		}

		public void Focused ()
		{
				animationAlpha = 1.0f;
		}
}

