using System;
using System.Collections.Generic;

namespace Json
{
	namespace MapData
	{
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

