using System.IO;
using UnityEngine;
using UnityEditor;
using MsgPack;

public class AssetExport
{
		static private string[] listExclusion = new string[] { ".DS_Store", ".svn" };
		private const int fileID = 1;
		private const int fileVersion = 1974;
		private const string strOutputFileList = "FileList";
		private const string strResource = "Resources";
		private const string strMetaFile = ".meta";
		private const string strBinaryFile = ".bytes";
		private const string kExtensionAssetBundle	= ".unity3d";
		// <summary>
		// 除外ファイルの検索 </summary>
		static bool IsExclusion (string name)
		{
				bool returncode = false;
				for (int i = 0; i < listExclusion.Length; ++i) {
						returncode |= name.Contains (listExclusion [i]);
				} 
				return returncode;
		}
		// <summary>
		// 対象フォルダー以下のオブジェクトからファイルリストを生成する </summary>
		static void CreateTargetFileList (string currentDirectory, string targetDirectory, out string[] lists, out Object[] assets)
		{
				string resourcesDirectory = currentDirectory + "/" + strResource;
				string compareTargetDirectory = resourcesDirectory + "/" + targetDirectory;
				string binaryFileListName = compareTargetDirectory + "/" + strOutputFileList + strBinaryFile;

				{	//  mazuha BinaryFile wo Exist saseru
						byte[] dummy = new byte[16];	// dummy
						File.WriteAllBytes (binaryFileListName, dummy);
				}
				string[] resFileNames = Directory.GetFiles (resourcesDirectory, "*.*", SearchOption.AllDirectories);
				string[] pickedListNames = new string[resFileNames.Length];
				int pickedListNamesCount = 0;
				// すべての生成された文字列の \\ を / に変換しておく
				compareTargetDirectory = compareTargetDirectory.Replace ("\\", "/");
				resourcesDirectory = resourcesDirectory.Replace ("\\", "/");
				foreach (string name in resFileNames) {
						string temp = name.Replace ("\\", "/");
						if ((IsExclusion (temp) == false)
						 && (temp.Contains (compareTargetDirectory) == true)
						 && (temp.Contains (strMetaFile) == false)) {
								temp = temp.Replace (resourcesDirectory + "/", "");
								temp = temp.Substring (0, temp.LastIndexOf ("."));
								pickedListNames [pickedListNamesCount] = temp;
								++pickedListNamesCount;
						}
				}

				assets = new Object[pickedListNamesCount];
				lists = new string[pickedListNamesCount];
				SerializeData.FileList fileList = new SerializeData.FileList ();
				for (int i = 0; i < pickedListNamesCount; ++i) {
						lists [i] = pickedListNames [i];
						assets [i] = Resources.Load (lists [i]);
						fileList.obj.Add (new Pair<string,string> (lists [i], assets [i].GetType ().FullName));
				}
				{	// File.Lst Binary Overwrite
						fileList.id = fileID;
						fileList.version = fileVersion;
						ObjectPacker packer = new ObjectPacker ();
						byte[] bytes = packer.Pack (fileList);
						File.WriteAllBytes (binaryFileListName, bytes);
						AssetDatabase.Refresh ();	// refresh
				}
		}

		// <summary>
		// 指定フォルダーを指定プラットフォームのAssetBundleを生成する </summary>
		public static void Build (string outPath, string resPath, BuildTarget target)
		{
				if (Directory.Exists (outPath) == false) {
						Directory.CreateDirectory (outPath);
				}

				string[] files;
				Object[] assets;
				CreateTargetFileList (Application.dataPath, resPath, out files, out assets);
 
				{	// FileListのload test.
						bool msgPackValidflag = false;
						foreach (Object obj in assets) {
								if (obj.name == strOutputFileList) {
										TextAsset msgBin = obj as TextAsset;
										ObjectPacker packerd = new ObjectPacker ();
										SerializeData.FileList flistd = packerd.Unpack<SerializeData.FileList> (msgBin.bytes);
										if (flistd.version == fileVersion) {
												msgPackValidflag = true;
												break;
										}
								}
						}
						if (msgPackValidflag == false) {
								Debug.Log ("ERROR:msgPack valid");
								return;
						}
				}
				Debug.Log (outPath + "/" + resPath + kExtensionAssetBundle);
				BuildAssetBundleOptions opt = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets;
				BuildPipeline.BuildAssetBundleExplicitAssetNames (assets, files, outPath + "/" + resPath + kExtensionAssetBundle, opt, target);
		}
}