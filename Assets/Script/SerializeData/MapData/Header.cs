// <copyright file="Header.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;

namespace SerializeData
{
		namespace MapData
		{
				/// <summary>
				/// Header
				/// </summary>
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
