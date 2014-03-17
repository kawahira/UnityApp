// <copyright file="Block.cs" >(C)2014</copyright>
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Asset
{
		// <summary>
		// リソース管理のブロック </summary>
		public class Block
		{
				protected int group;
				protected int id;
				protected int version;
				protected bool readFlag;
				protected bool callbackFlag;
				protected bool autoremove;
				protected float progress;
				protected long size;
				public string url;
				public string folder;
				// <summary>
				// コンストラクタ </summary>
				protected Block (string urlName, string folderName, int groupName, int idNumber, int versionNumber)
				{
						group = groupName;
						id = idNumber;
						version = versionNumber;
						readFlag = false;
						callbackFlag	= false;
						progress = 0.0f;
						url = urlName;
						folder = folderName;
						size = 0;
						autoremove = false;
				}
				// <summary>
				// 読み込み中かの判定 </summary>
				public bool IsRead ()
				{
						return readFlag == true && callbackFlag == true;
				}
				// <summary>
				// 自動的に解放を行う </summary>
				public bool IsAutoRemoved ()
				{
						return autoremove;
				}
				// <summary>
				// ブロックの利用しているメモリサイズを返す </summary>
				public long GetSize ()
				{
						return size;
				}
				// <summary>
				// 読み込み時の進行度( 0 ~ 1 ) </summary>
				public float GetProgress ()
				{
						return progress;
				}
				// <summary>
				// 読み込み後に行われる解決処理 </summary>
				public virtual void Resolve ()
				{
				}
				// <summary>
				// 読み込み処理 </summary>
				public virtual IEnumerator Read ()
				{
						return null;
				}
				// <summary>
				// 解決処理時に呼ばれるコールバック </summary>
				public virtual IEnumerator Callback ()
				{
						Resolve ();
						yield return null;
						callbackFlag = true;
				}
		}
}

