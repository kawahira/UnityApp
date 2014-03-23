using System;
using System.Collections.Generic;
using UnityEngine;

namespace SerializeData
{
		/// <summary>
		/// Setting
		/// </summary>
		[System.Serializable]
		public class Setting
		{
				public string platformURLPrefix;
				public List<Pair<RuntimePlatform,string>> platformURL = new List<Pair<RuntimePlatform,string>>();
				// <summary>
				// リソースのURLを取得(フォルダー指定） </summary>
				public string GetResourceURL(string folderName)
				{
						return GetResourceURL() + "/" + folderName;
				}
				// <summary>
				// リソースのURLを取得(Root Folder） </summary>
				public string GetResourceURL()
				{
						return platformURLPrefix + "/" + GetPlatformURL(Application.platform);
				}
				// <summary>
				// プラットフォームフォルダーのみ取得 </summary>
				public string GetPlatformURL(RuntimePlatform platform)
				{
					return platformURL.Find(delegate(Pair<RuntimePlatform,string> d) { return d.Key == platform; }).Value;
				}
		}
}
