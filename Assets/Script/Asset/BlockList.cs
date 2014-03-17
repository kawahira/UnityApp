using System;
using System.Collections;
using System.Collections.Generic;

namespace Asset
{
		public class BlockList
		{
				private List<Block>	list = new List<Block> ();
				public string RootURL;

				public void Add (Block block)
				{
						list.Add (block);
				}
		}
}