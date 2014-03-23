using System;
using System.Collections.Generic;

namespace SerializeData
{
		/// <summary>
		/// Sequence
		/// </summary>
		[System.Serializable]
		public class Sequence
		{
				public string name;
				public string abort;
				public string next;
				public List<string>	sceneList = new List<string>();
				public bool isLoop;
				public Sequence (string seqName)
				{
					name = seqName;
					isLoop = false;
					Next(string.Empty);
				}
				public void Next (string seqName)
				{
					next = seqName;
				}
		}
}

