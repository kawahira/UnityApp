using System;
using System.Collections.Generic;
using UnityEngine;

namespace SerializeData
{
		/// <summary>
		/// Scene </summary>
		[System.Serializable]
		public class Scene {
			public string name;
			public string functionName;
			public List<string> files = new List<string>();
			public Scene (string sceneFunctionName, string uniqName)
			{
				functionName = sceneFunctionName;
				name = uniqName == null ? functionName : uniqName;
			}
		}
}

