using System;
using System.Collections.Generic;

namespace SerializeData
{
		/// <summary>
		/// FileList
		/// </summary>
		[System.Serializable]
		public class FileList
		{
				public int version;
				public int id;
				public List<Pair<string,string>> obj = new List<Pair<string,string>> ();
		}
}
 
