using UnityEngine;
using System;
public class Boot : Scene
{
	public override Scene GetNext()
	{
		return new Title();
	}
	public override void RequestLoad()
	{
			
	}
}
