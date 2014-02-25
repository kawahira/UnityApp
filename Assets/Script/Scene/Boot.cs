using System;

public class Boot : Scene
{
	public override void RequestLoad()
	{
	}
	public override void RequestStart()
	{
	}
	public override void RequestUnload()
	{
	}
	public override bool isDone()
	{
		return true;
	}
	public override bool isUnload()
	{
		return true;
	}
	public override Scene GetNext()
	{
		return new Title();
	}
}
