using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
		public class Resource
		{
				private static volatile Resource instance				= null;
				private static object syncRoot 										= new object ();
				public List<SerializeData.Scene> sceneList 				= new List<SerializeData.Scene>();
				public List<SerializeData.Sequence> sequenceList 	= new List<SerializeData.Sequence>();
				public	SerializeData.Setting setting 						= new SerializeData.Setting();
				public Resource ()
				{
						buildSettingData();
				}
				/// <summary>
				/// シングルトン取得 
				/// </summary>
				public static Resource Instance {
						get {
								if (instance == null) {
										lock (syncRoot) {
												if (instance == null)
													instance = new Resource ();
										}
								}
								return instance;
						}
				}
				private void buildSettingData() {
					setting.platformURLPrefix = "https://dl.dropboxusercontent.com/u/86805032/AssetBundle";
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.Android						,"Android"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.BB10Player 				,"BlackBerry"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.NaCl 							,"GoogleNative"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.IPhonePlayer 			,"iOS"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.LinuxPlayer 				,"Linux"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.MetroPlayerARM 		,"Metro"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.OSXDashboardPlayer ,"OSXIntel"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.OSXWebPlayer 			,"WebPlayer"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.WindowsPlayer 			,"Windows"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.WP8Player 					,"WindowsPhone8"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.FlashPlayer 				,"Flash"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.TizenPlayer 				,"Tizen"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.PS3 								,"PS3"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.WiiPlayer 					,"Wii"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.XBOX360 						,"XBOX360"));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.MetroPlayerX64 		,setting.GetPlatformURL(RuntimePlatform.MetroPlayerARM)));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.MetroPlayerX86 		,setting.GetPlatformURL(RuntimePlatform.MetroPlayerARM)));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.WindowsWebPlayer 	,setting.GetPlatformURL(RuntimePlatform.OSXWebPlayer)));		
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.OSXEditor 					,setting.GetPlatformURL(RuntimePlatform.OSXDashboardPlayer)));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.OSXPlayer 					,setting.GetPlatformURL(RuntimePlatform.OSXDashboardPlayer)));
					setting.platformURL.Add(new Pair<RuntimePlatform,string>(RuntimePlatform.WindowsEditor 			,setting.GetPlatformURL(RuntimePlatform.WindowsPlayer)));
					{
							SerializeData.Scene scene = new SerializeData.Scene(typeof(Scene.Boot).FullName, null);
							scene.files.Add("Mapchip");
							sceneList.Add(scene);
					}
					{
							SerializeData.Scene scene = new SerializeData.Scene(typeof(Scene.Base).FullName, "Adv-1");
							scene.files.Add("System");
							sceneList.Add(scene);
					}
					{
							SerializeData.Scene scene = new SerializeData.Scene(typeof(Scene.Base).FullName, "Adv-2");
							scene.files.Add("Prefab");
							sceneList.Add(scene);
					}
					{
							SerializeData.Scene scene = new SerializeData.Scene(typeof(Scene.Title).FullName, null);
							sceneList.Add(scene);
					}

					{
							SerializeData.Sequence sequence = new SerializeData.Sequence("Boot");
							sequence.sceneList.Add(sceneList[0].name);
							sequence.sceneList.Add(sceneList[3].name);
							sequence.Next("LoopDemo");
							sequenceList.Add(sequence);
					}
					{
							SerializeData.Sequence sequence = new SerializeData.Sequence("LoopDemo");
							sequence.sceneList.Add(sceneList[1].name);
							sequence.sceneList.Add(sceneList[2].name);
							sequence.isLoop = true;
							sequenceList.Add(sequence);
					}
				}
		}
}

