using UnityEditor;
using System.IO;

public class Build
{
		// <summary>
		// プロジェクトのビルド </summary>
		public static void Project (BuildTarget target, BuildOptions options, string outputName)
		{
				string directoryName = Path.GetDirectoryName (outputName);
				if (Directory.Exists (directoryName) == true) {
						Directory.Delete (directoryName, true);
				}
				Directory.CreateDirectory (directoryName);
				EditorUserBuildSettings.SwitchActiveBuildTarget (target);
				string[] allScene = new string[EditorBuildSettings.scenes.Length];
				int count = 0;
				foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
						allScene [count++] = scene.path;
				}
				string errorMsg = BuildPipeline.BuildPlayer (allScene, outputName, target, options);
				if (string.IsNullOrEmpty (errorMsg) == false) {
						UnityEngine.Debug.Log (errorMsg);
						StreamWriter sw = new StreamWriter (directoryName + "/" + "BuildError.log", true);
						sw.WriteLine (errorMsg);
						sw.Close ();
						throw new System.ArgumentException ();
				}
		}
}
