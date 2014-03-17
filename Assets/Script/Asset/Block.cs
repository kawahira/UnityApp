// <copyright file="Block.cs" >(C)2014</copyright>
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Asset
{
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
		protected Block(string urlName,string folderName, int groupName, int idNumber,int versionNumber)
		{
			group			= groupName;
			id				= idNumber;
			version			= versionNumber;
			readFlag		= false;
			callbackFlag	= false;
			progress 		= 0.0f;
			url 			= urlName;
			folder			= folderName ;
			size			= 0;
			autoremove		= false;
		}
		public bool IsRead() 				{ return readFlag == true && callbackFlag == true; }
		public bool IsAutoRemoved()			{ return autoremove; }
		public long GetSize()				{ return size; }
		public float GetProgress() 			{ return progress; }
		public virtual void Resolve()		{ }
		public virtual IEnumerator Read()	{ return null; }
		public virtual IEnumerator Callback()
		{
			Resolve();
			yield return null;
			callbackFlag = true;
		}
	}
}

