using System;

public class Boot : Scene
{
	public override Scene GetNext()
	{
		return new Title();
	}
}
