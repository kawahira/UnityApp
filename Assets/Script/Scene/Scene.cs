// <copyright file="Scene.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Scene
{
	public enum EndStatus
	{
		NEXT,
		BACK,
		ABORT,
	};
	public class Base
	{
			private int count;
			public SerializeData.Scene data;
			public EndStatus endStatus;
	    public void Initialize (SerializeData.Scene serializeData)
			{
				count = 0;
	    	endStatus = EndStatus.NEXT;
				data = serializeData;
	    }
			public virtual void RequestLoad (ref List<Asset.Block> blocks)
			{
				if ( data != null )
				{
					for ( int i = 0 ; i < data.files.Count ; ++i )
					{
						blocks.Add (new Asset.Bundle (Game.Resource.Instance.setting.GetResourceURL(data.files[i]), data.files[i], 0, 0, 1, null));
					}	
				}
			}

			public virtual void RequestStart ()
			{
			}

			public virtual void RequestUnload ()
			{
			}

			public virtual bool IsLoad ()
			{
					++count;
					return count > 600 ? true : false;
			}

			public virtual bool IsDone ()
			{
					return true;
			}

			public virtual bool IsUnload ()
			{
					return true;
			}

			public virtual void DebugDraw (float x,float y)
			{
					StringBuilder text = new StringBuilder ();
					text.Append ("Scene : " + GetType ().Name + "\n");
					text.Append ("Files : " + data.files.Count + "\n");
					data.files.ForEach(delegate(string name)
					{
							text.Append ("LoadFile : " + name + "\n");
					});
					text.Append ("Count : " + count.ToString ("0") + "\n");
					GUI.Box (new Rect (x, y, 310, 100), text.ToString ());
			}
	}
}
