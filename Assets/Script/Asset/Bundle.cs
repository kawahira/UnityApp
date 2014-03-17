// <copyright file="Bundle.cs" >(C)2014</copyright>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using MsgPack;

namespace Asset
{
	public class Bundle : Block
	{
		private int wwwCount	 					= 0;
		private int loadASyncCount 						= 0;
		private int msgpackCount 					= 0;
		private SerializeData.FileList fileList	= null;
		private List<object> objectList			= new  List<object>();
		private System.Action<List<object>,SerializeData.FileList> callback = null;
		private const string strFileListName 			= "FileList";
		private const string strExtensionAssetBundle 	= ".unity3d";
		public Bundle(string url,string folder, int group,int id,int version,System.Action<List<object>,SerializeData.FileList> cb) : base(url,folder,group,id,version)
		{
			callback = cb;
			autoremove = true;
		}
		public override IEnumerator Read()
		{
			do
			{
				using(WWW www = WWW.LoadFromCacheOrDownload (url + strExtensionAssetBundle, version))
				{
					while (!www.isDone)
					{
						progress = www.progress;
						++wwwCount;
						yield return null;
					}
					string errorMessage = string.Empty;
					if (www.error != null)
					{
						errorMessage += www.error;
					}
					if ( www.assetBundle == null )
					{
						errorMessage += "/null AssetBundle";
					}
					if ( errorMessage != string.Empty )
					{
						Debug.Log(errorMessage + "(AssetName:" + url + ")");
					}
 					else
					{
						Debug.Log ("www:" + wwwCount);
						{
							// オブジェクトを非同期ロード
							AssetBundleRequest request = www.assetBundle.LoadAsync(folder + "/" + strFileListName,typeof(TextAsset));
							while (!request.isDone)
							{
                                ++loadASyncCount;
 								yield return null;
							}
                            Debug.Log("loadASync[" + kFileListName + "]:" + loadASyncCount);
							Thread thread = new Thread(new ParameterizedThreadStart(UnpackFileList ));
							thread.Priority = System.Threading.ThreadPriority.Lowest;
							thread.Start( (request.asset as TextAsset).bytes );
							while (thread.IsAlive)
							{
								++msgpackCount;
								yield return null;
							}
						}
						Debug.Log ("msgpack:" + msgpackCount);
						aSyncCount = 0;
						for ( int i = 0 ; i < fileList.obj.Count ; ++i )
						{
							if ( fileList.obj[i].Key == folder + "/" + kFileListName ) continue;	// FileList skip.
							AssetBundleRequest request = www.assetBundle.LoadAsync(fileList.obj[i].Key,WrapClass.GetType(fileList.obj[i].Value));
							while (!request.isDone)
							{
                                ++loadASyncCount;
								yield return null;
							}
							objectList.Add(request.asset);
						}
                        Debug.Log("aSyncCount:" + loadASyncCount);
						Debug.Log (fileList.version);
						// threadの解放コードのお手本にはJoinが書かれているが mainthreadが止まるし目的が違うのでいらないはず
						www.assetBundle.Unload(false);
						readFlag	= true;
					}
					yield return null;
				}
			} while(readFlag == false);
		}
		public override void Resolve()
		{
			if ( callback != null )
			{
				callback(objectList, fileList);
			}
		}
		private void UnpackFileList(object obj)
		{
			byte[] bytes = (byte[])obj;
			ObjectPacker packerd = new ObjectPacker();
			fileList = packerd.Unpack<SerializeData.FileList>(bytes);
		}
	}
}
