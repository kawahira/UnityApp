using System;
using System.Collections.Generic;

namespace Json
{
	namespace MapData
	{
		[System.Serializable]
		public struct Tilesets
		{
			public int firstgid;
			public string image;
			public int imageheight;
			public int imagewidth;
			public int margin;
			public string name;
			public List<string> properties;
			public int spacing;
			public List<Terrains> terrains;
			public int tileheight;
			public int tilewidth;
		}
	}
}

