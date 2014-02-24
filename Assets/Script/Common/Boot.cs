/*
using UnityEngine;
using System.Collections;
using System;
using System.IO;

/// <summary>
/// Boot.
/// </summary>
public class Boot : MonoBehaviour 
{
	/// <summary>
	/// Boot JSO.
	/// </summary>
	public class BootJSON
	{
		public bool DispDebugInfo = true; 
 		public bool test = false;
	}
//	[SerializeField] string JsonFileName = "boot.json";
	[SerializeField] BootJSON inifile = new BootJSON();
	[SerializeField] GameObject DebugInfoPrefab = null;
	/// <summary>
	/// Start this instance.
	/// </summary>
  	void Start ()
	{
		CreatePrefab();
	}
	/// <summary>
	/// Creates the prefab.
	/// </summary>
	void CreatePrefab()
	{
		if ( inifile.DispDebugInfo )
		{
			Instantiate(DebugInfoPrefab);
		}
	}
	/// <summary>
	/// Loads the json.
	/// </summary>
	/// <param name='json'>
	/// Json.
	/// </param>
	void loadJson(string json)
	{
	}
	/// <summary>
	/// Write the specified filename.
	/// </summary>
	/// <param name='filename'>
	/// Filename.
	/// </param>
}
*/