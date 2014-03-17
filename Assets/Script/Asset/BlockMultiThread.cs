// <copyright file="BlockMultiThread.cs" >(C)2014</copyright>
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Asset
{
	public class BlockMultiThread : Block
	{
		public BlockMultiThread(string url,string folder, int group,int id,int version) : base(url,folder,group,id,version) { }
		public override IEnumerator Callback()
		{
			Thread thread = new Thread( Resolve );
			{
				thread.Priority = System.Threading.ThreadPriority.Lowest;
	   			thread.Start();
				while (thread.IsAlive)
				{
					yield return null;
				}
				// threadの解放コードのお手本にはJoinが書かれているが mainthreadが止まるし目的が違うのでいらないはず
				callbackFlag = true;
			}
		}
	}
}
