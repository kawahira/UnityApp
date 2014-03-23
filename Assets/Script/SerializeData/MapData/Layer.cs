// <copyright file="Layer.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;

namespace SerializeData
{
		namespace MapData
		{
				/// <summary>
				/// Layer
				/// </summary>
				[System.Serializable]
				public class Layer
				{
						public List<int> data;
						public int height;
						public string name;
						public int opacity;
						public string type;
						public bool visible;
						public int width;
						public int x;
						public int y;
				}
		}
}

