using System;
using System.Collections.Generic;

namespace Json
{
	namespace MapData
	{
		[System.Serializable]
		public struct Header
		{
			public int height;
			public List<Layer> layers;
			public string orientation;
			public List<string> properties;
			public int tileheight;
			public List<Tilesets> tilesets;
			public int tilewidth;
			public int version;
			public int width;
		}
	}
}
