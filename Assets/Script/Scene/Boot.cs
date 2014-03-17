// <copyright file="Boot.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 起動シーン
/// </summary>
public class Boot : Scene
{
	private const string serverDomainName 	= "https://dl.dropboxusercontent.com/";
	private const string testStageURL 		= serverDomainName + "s/chq04dckn9vt0bi/TestStage.txt";
	private const string mapChipBaseURL 	= serverDomainName + "s/6asb4ckkcv7afth";
	private const string magicianBaseURL 	= serverDomainName + "s/9gmjt38enzv24oa/Magician";
	private const string MapChipName 		= "Mapchip";
	private const string MagicianName 		= "Animation/Magician";
	/// <summary>
	/// 次のシーン
	/// </summary>
	public override Scene GetNext()
	{
//		return new Title();
		return new Boot();
	}
	public override void RequestLoad(ref List<Asset.Block> blocks)
	{
//		blocks.Add(new Asset.Text(testStageURL, 0, 0, 0, null));
		blocks.Add(new Asset.Bundle(mapChipBaseURL + "/" + MapChipName, MapChipName , 0, 0, 1, null));
	}
	public override void RequestUnload()
	{
//		blocks.ForEach (
	}
}
 