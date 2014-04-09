// <copyright file="Boot.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scene
{
	/// <summary>
	/// 起動シーン </summary>
	public class Boot : Base
	{
	       /// <summary>
	       /// 初期化 </summary>
	        public Boot()
	        {
	            RandXorShift.Instance.Seed(1);
	        }
	        public override void RequestUnload ()
	        {
	        }
	}
}
 