using UnityEditor;

public class buildMenu
{
		const bool enableWindows = true;
		const bool enableLinux = true;
		const bool enableMac = true;
		const bool enableiPhone = true;
		const bool enableAndroid = true;
		const bool enableBlackBerry = false;
		const bool enableWebPlayer = true;
		const bool enableGoogleNative = true;
		const bool enableMetro = false;
		const bool enableWindowsPhone8 = false;
		const string kScriptDebug = "-" + "ScriptDebug";
		const string kAutoProfiler = "-" + "AutoProfiler";
		const string kOffline = "Offline";
		const string kStreamed = "Streamed";
		const string kNaCL = "NaCL";
		const string kWindows = "Windows";
		const string kMac = "OSXIntel";
		const string kLinux = "Linux";
		const string kiOS = "iOS";
		const string kAndroid = "Android";
		const string kBlackBerry = "BlackBerry";
		const string kMetro = "Metro";
		const string kWindowsPhone8 = "WindowsPhone8";
		const string kGoogleNative = "GoogleNative";
		const string kCpu86 = "32bit";
		const string kCpu64 = "64bit";
		const string kCpuUniversal = "Universal";
		const string kWebPlayer = "WebPlayer";
		const string kDefault = "Basic";
		const string kAssetBundle = "AssetBundle";
		const string kWindows86 = "/" + kWindows + "/" + kCpu86;
		const string kWindows64 = "/" + kWindows + "/" + kCpu64;
		const string kMac86 = "/" + kMac + "/" + kCpu86;
		const string kMac64 = "/" + kMac + "/" + kCpu64;
		const string kMacUniversal = "/" + kMac + "/" + kCpuUniversal;
		const string kLinux86 = "/" + kLinux + "/" + kCpu86;
		const string kLinux64 = "/" + kLinux + "/" + kCpu64;
		const string kLinuxUniversal = "/" + kLinux + "/" + kCpuUniversal;
		const string kWebPlayerDefault = "/" + kWebPlayer + "/" + kDefault;
		const string kWebPlayerOffline = "/" + kWebPlayer + "/" + kOffline;
		const string kWebPlayerStream = "/" + kWebPlayer + "/" + kStreamed;
		const string kWebPlayerNaCL = "/" + kWebPlayer + "/" + kNaCL;
		const string kiOSDefault = "/" + kiOS + "/" + kDefault;
		const string kAndroidDefault = "/" + kAndroid + "/" + kDefault;
		const string kBlackBerryDefault = "/" + kBlackBerry + "/" + kDefault;
		const string kMetroDefault = "/" + kMetro + "/" + kDefault;
		const string kWindowsPhone8Default = "/" + kWindowsPhone8 + "/" + kDefault;
		const string kGoogleNativeDefault = "/" + kGoogleNative + "/" + kDefault;
		const string kBuild = "Build";
		const string kDevelopment = kBuild + "/" + "Development";
		const string kRelease = kBuild + "/" + "Release";
		const string kExtensionMac = ".app";
		const string kExtensionWindows = ".exe";
		const string kExtensionAndroid = ".apk";
		const string kExtensionBlackBerry	= ".bar";
		const string kMapChip = "Mapchip";
		const string kSystem = "System";
		const string kPrefab = "Prefab";
		const string kMagician = "Animation/Magician";
		static private string productName = "/" + PlayerSettings.productName;
		const BuildOptions optDevelop = BuildOptions.Development;
		const BuildOptions optDevelopScriptDebug = BuildOptions.Development | BuildOptions.AllowDebugging;
		const BuildOptions optDevelopAutoProfiler = BuildOptions.Development | BuildOptions.ConnectWithProfiler | BuildOptions.AutoRunPlayer;
		const BuildOptions optRelease = BuildOptions.None;
		// <summary> Mac86 Development build </summary>
		[UnityEditor.MenuItem (kDevelopment + kMac86)]
		public static void Mac86_Development ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel, optDevelop, kDevelopment + kMac86 + productName + kExtensionMac);
		}
		// <summary> Mac86 Development + Script Debug build </summary>
		[UnityEditor.MenuItem (kDevelopment + kMac86 + kScriptDebug)]
		public static void Mac86_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel, optDevelopScriptDebug, kDevelopment + kMac86 + kScriptDebug + productName + kExtensionMac);
		}
		// <summary> Mac86 Development + AutoProfiler build </summary>
		[UnityEditor.MenuItem (kDevelopment + kMac86 + kAutoProfiler)]
		public static void Mac86_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel, optDevelopAutoProfiler, kDevelopment + kMac86 + kAutoProfiler + productName + kExtensionMac);
		}
		// <summary> Mac86 Release build </summary>
		[UnityEditor.MenuItem (kRelease + kMac86)]
		public static void Mac86_Release ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel, optRelease, kRelease + kMac86 + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kMac64)]
		public static void Mac64_Development ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel64, optDevelop, kDevelopment + kMac64 + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kMac64 + kScriptDebug)]
		public static void Mac64_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel64, optDevelopScriptDebug, kDevelopment + kMac64 + kScriptDebug + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kMac64 + kAutoProfiler)]
		public static void Mac64_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel64, optDevelopAutoProfiler, kDevelopment + kMac64 + kAutoProfiler + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kRelease + kMac64)]
		public static void Mac64_Release ()
		{
				Build.Project (BuildTarget.StandaloneOSXIntel64, optRelease, kRelease + kMac64 + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kMacUniversal)]
		public static void MacUniversal_Development ()
		{
				Build.Project (BuildTarget.StandaloneOSXUniversal, optDevelop, kDevelopment + kMacUniversal + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kMacUniversal + kScriptDebug)]
		public static void MacUniversal_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneOSXUniversal, optDevelopScriptDebug, kDevelopment + kMacUniversal + kScriptDebug + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kMacUniversal + kAutoProfiler)]
		public static void MacUniversal_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneOSXUniversal, optDevelopAutoProfiler, kDevelopment + kMacUniversal + kAutoProfiler + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kRelease + kMacUniversal)]
		public static void MacUniversal_Release ()
		{
				Build.Project (BuildTarget.StandaloneOSXUniversal, optRelease, kRelease + kMacUniversal + productName + kExtensionMac);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinux86)]
		public static void Linux86_Development ()
		{
				Build.Project (BuildTarget.StandaloneLinux, optDevelop, kDevelopment + kLinux86 + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinux86 + kScriptDebug)]
		public static void Linux86_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneLinux, optDevelopScriptDebug, kDevelopment + kLinux86 + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinux86 + kAutoProfiler)]
		public static void Linux86_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneLinux, optDevelopAutoProfiler, kDevelopment + kLinux86 + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kLinux86)]
		public static void Linux86_Release ()
		{
				Build.Project (BuildTarget.StandaloneLinux, optRelease, kRelease + kLinux86 + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinux64)]
		public static void Linux64_Development ()
		{
				Build.Project (BuildTarget.StandaloneLinux64, optDevelop, kDevelopment + kLinux64 + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinux64 + kScriptDebug)]
		public static void Linux64_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneLinux64, optDevelopScriptDebug, kDevelopment + kLinux64 + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinux64 + kAutoProfiler)]
		public static void Linux64_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneLinux64, optDevelopAutoProfiler, kDevelopment + kLinux64 + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kLinux64)]
		public static void Linux64_Release ()
		{
				Build.Project (BuildTarget.StandaloneLinux64, optRelease, kRelease + kLinux64 + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinuxUniversal)]
		public static void LinuxUniversal_Development ()
		{
				Build.Project (BuildTarget.StandaloneLinuxUniversal, optDevelop, kDevelopment + kLinuxUniversal + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinuxUniversal + kScriptDebug)]
		public static void LinuxUniversal_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneLinuxUniversal, optDevelopScriptDebug, kDevelopment + kLinuxUniversal + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kLinuxUniversal + kAutoProfiler)]
		public static void LinuxUniversal_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneLinuxUniversal, optDevelopAutoProfiler, kDevelopment + kLinuxUniversal + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kLinuxUniversal)]
		public static void LinuxUniversal_Release ()
		{
				Build.Project (BuildTarget.StandaloneLinuxUniversal, optRelease, kRelease + kLinuxUniversal + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerDefault)]
		public static void WebPlayerDefault_Development ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelop, kDevelopment + kWebPlayerDefault + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerDefault + kScriptDebug)]
		public static void WebPlayerDefault_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopScriptDebug, kDevelopment + kWebPlayerDefault + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerDefault + kAutoProfiler)]
		public static void WebPlayerDefault_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopAutoProfiler, kDevelopment + kWebPlayerDefault + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kWebPlayerDefault)]
		public static void WebPlayerDefault_Release ()
		{
				Build.Project (BuildTarget.WebPlayer, optRelease, kRelease + kWebPlayerDefault + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerOffline)]
		public static void WebPlayerOffline_Development ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelop, kDevelopment + kWebPlayerOffline + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerOffline + kScriptDebug)]
		public static void WebPlayerOffline_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopScriptDebug, kDevelopment + kWebPlayerOffline + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerOffline + kAutoProfiler)]
		public static void WebPlayerOffline_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopAutoProfiler, kDevelopment + kWebPlayerOffline + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kWebPlayerOffline)]
		public static void WebPlayerOffline_Release ()
		{
				Build.Project (BuildTarget.WebPlayer, optRelease, kRelease + kWebPlayerOffline + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerStream)]
		public static void WebPlayerStream_Development ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelop, kDevelopment + kWebPlayerStream + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerStream + kScriptDebug)]
		public static void WebPlayerStream_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopScriptDebug, kDevelopment + kWebPlayerStream + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerStream + kAutoProfiler)]
		public static void WebPlayerStream_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopAutoProfiler, kDevelopment + kWebPlayerStream + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kWebPlayerStream)]
		public static void WebPlayerStream_Release ()
		{
				Build.Project (BuildTarget.WebPlayer, optRelease, kRelease + kWebPlayerStream + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerNaCL)]
		public static void WebPlayerNaCL_Development ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelop, kDevelopment + kWebPlayerNaCL + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerNaCL + kScriptDebug)]
		public static void WebPlayerNaCL_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopScriptDebug, kDevelopment + kWebPlayerNaCL + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWebPlayerNaCL + kAutoProfiler)]
		public static void WebPlayerNaCL_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.WebPlayer, optDevelopAutoProfiler, kDevelopment + kWebPlayerNaCL + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kWebPlayerNaCL)]
		public static void WebPlayerNaCL_Release ()
		{
				Build.Project (BuildTarget.WebPlayer, optRelease, kRelease + kWebPlayerNaCL + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindows86)]
		public static void Win86_Development ()
		{
				Build.Project (BuildTarget.StandaloneWindows, optDevelop, kDevelopment + kWindows86 + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindows86 + kScriptDebug)]
		public static void Win86_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneWindows, optDevelopScriptDebug, kDevelopment + kWindows86 + kScriptDebug + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindows86 + kAutoProfiler)]
		public static void Win86_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneWindows, optDevelopAutoProfiler, kDevelopment + kWindows86 + kAutoProfiler + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kRelease + kWindows86)]
		public static void Win86_Release ()
		{
				Build.Project (BuildTarget.StandaloneWindows, optRelease, kRelease + kWindows86 + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindows64)]
		public static void Win64_Development ()
		{
				Build.Project (BuildTarget.StandaloneWindows64, optDevelop, kDevelopment + kWindows64 + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindows64 + kScriptDebug)]
		public static void Win64_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.StandaloneWindows64, optDevelopScriptDebug, kDevelopment + kWindows64 + kScriptDebug + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindows64 + kAutoProfiler)]
		public static void Win64_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.StandaloneWindows64, optDevelopAutoProfiler, kDevelopment + kWindows64 + kAutoProfiler + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kRelease + kWindows64)]
		public static void Win64_Release ()
		{
				Build.Project (BuildTarget.StandaloneWindows64, optRelease, kRelease + kWindows64 + productName + kExtensionWindows);
		}

		[UnityEditor.MenuItem (kDevelopment + kiOSDefault)]
		public static void iOS_Development ()
		{
				Build.Project (BuildTarget.iPhone, optDevelop, kDevelopment + kiOSDefault + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kiOSDefault + kScriptDebug)]
		public static void iOS_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.iPhone, optDevelopScriptDebug, kDevelopment + kiOSDefault + kScriptDebug + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kiOSDefault + kAutoProfiler)]
		public static void iOS_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.iPhone, optDevelopAutoProfiler, kDevelopment + kiOSDefault + kAutoProfiler + productName);
		}

		[UnityEditor.MenuItem (kRelease + kiOSDefault)]
		public static void iOS_Release ()
		{
				Build.Project (BuildTarget.iPhone, optRelease, kRelease + kiOSDefault + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + kAndroidDefault)]
		public static void Android_Development ()
		{
				Build.Project (BuildTarget.Android, optDevelop, kDevelopment + kAndroidDefault + productName + kExtensionAndroid);
		}

		[UnityEditor.MenuItem (kDevelopment + kAndroidDefault + kScriptDebug)]
		public static void Android_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.Android, optDevelopScriptDebug, kDevelopment + kAndroidDefault + kScriptDebug + productName + kExtensionAndroid);
		}

		[UnityEditor.MenuItem (kDevelopment + kAndroidDefault + kAutoProfiler)]
		public static void Android_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.Android, optDevelopAutoProfiler, kDevelopment + kAndroidDefault + kAutoProfiler + productName + kExtensionAndroid);
		}

		[UnityEditor.MenuItem (kRelease + kAndroidDefault)]
		public static void Android_Release ()
		{
				Build.Project (BuildTarget.Android, optRelease, kRelease + kAndroidDefault + productName + kExtensionAndroid);
		}

		[UnityEditor.MenuItem (kDevelopment + kBlackBerryDefault)]
		public static void BlackBerry_Development ()
		{
				Build.Project (BuildTarget.BB10, optDevelop, kDevelopment + kBlackBerryDefault + productName + kExtensionBlackBerry);
		}

		[UnityEditor.MenuItem (kDevelopment + kBlackBerryDefault + kScriptDebug)]
		public static void BlackBerry_Development_ScriptDebug ()
		{
				Build.Project (BuildTarget.BB10, optDevelopScriptDebug, kDevelopment + kBlackBerryDefault + kScriptDebug + productName + kExtensionBlackBerry);
		}

		[UnityEditor.MenuItem (kDevelopment + kBlackBerryDefault + kAutoProfiler)]
		public static void BlackBerry_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.BB10, optDevelopAutoProfiler, kDevelopment + kBlackBerryDefault + kAutoProfiler + productName + kExtensionBlackBerry);
		}

		[UnityEditor.MenuItem (kRelease + kBlackBerryDefault)]
		public static void BlackBerry_Release ()
		{
				Build.Project (BuildTarget.BB10, optRelease, kRelease + kBlackBerryDefault + productName + kExtensionBlackBerry);
		}

		[UnityEditor.MenuItem (kDevelopment + kMetroDefault)]
		public static void Metro_Development ()
		{
				Build.Project (BuildTarget.MetroPlayer, optDevelop, kDevelopment + kMetroDefault);
		}

		[UnityEditor.MenuItem (kDevelopment + kMetroDefault + kAutoProfiler)]
		public static void Metro_Development_AutoProfiler ()
		{
				Build.Project (BuildTarget.MetroPlayer, optDevelopAutoProfiler, kDevelopment + kMetroDefault + kAutoProfiler);
		}

		[UnityEditor.MenuItem (kRelease + kMetroDefault)]
		public static void Metro_Release ()
		{
				Build.Project (BuildTarget.MetroPlayer, optRelease, kRelease + kMetroDefault);
		}

		[UnityEditor.MenuItem (kDevelopment + kWindowsPhone8Default)]
		public static void WindowsPhone8_Development ()
		{
				Build.Project (BuildTarget.WP8Player, optDevelop, kDevelopment + kWindowsPhone8Default);
		}

		[UnityEditor.MenuItem (kRelease + kWindowsPhone8Default)]
		public static void WindowsPhone8_Release ()
		{
				Build.Project (BuildTarget.WP8Player, optRelease, kRelease + kWindowsPhone8Default);
		}

		[UnityEditor.MenuItem (kDevelopment + kGoogleNativeDefault)]
		public static void NaCl_Development ()
		{
				Build.Project (BuildTarget.NaCl, optDevelop, kDevelopment + kGoogleNativeDefault + productName);
		}

		[UnityEditor.MenuItem (kRelease + kGoogleNativeDefault)]
		public static void NaCl_Release ()
		{
				Build.Project (BuildTarget.NaCl, optRelease, kRelease + kGoogleNativeDefault + productName);
		}

		[UnityEditor.MenuItem (kDevelopment + "/All")]
		public static void AllBuildDevelopment ()
		{
				if (enableMac) {
						Mac86_Development ();
						Mac86_Development_ScriptDebug ();
						Mac64_Development ();
						Mac64_Development_ScriptDebug ();
						MacUniversal_Development ();
						MacUniversal_Development_ScriptDebug ();
				}
				if (enableLinux) {
						Linux86_Development ();
						Linux86_Development_ScriptDebug ();
						Linux64_Development ();
						Linux64_Development_ScriptDebug ();
						LinuxUniversal_Development ();
						LinuxUniversal_Development_ScriptDebug ();
				}
				if (enableWindows) {
						Win86_Development ();
						Win86_Development_ScriptDebug ();
						Win64_Development ();
						Win64_Development_ScriptDebug ();
				}
				if (enableWebPlayer) {
						WebPlayerDefault_Development ();
						WebPlayerDefault_Development_ScriptDebug ();
						WebPlayerOffline_Development ();
						WebPlayerOffline_Development_ScriptDebug ();
						WebPlayerStream_Development ();
						WebPlayerStream_Development_ScriptDebug ();
						WebPlayerNaCL_Development ();
						WebPlayerNaCL_Development_ScriptDebug ();
				}
				if (enableiPhone) {
						iOS_Development ();
						iOS_Development_ScriptDebug ();
				}
				if (enableAndroid) {
						Android_Development ();
						Android_Development_ScriptDebug ();
				}
				if (enableBlackBerry) {
						BlackBerry_Development ();
						BlackBerry_Development_ScriptDebug ();
				}
				if (enableMetro) {
						Metro_Development ();
						Metro_Development_AutoProfiler ();
				}
				if (enableWindowsPhone8) {
						WindowsPhone8_Development ();
				}
				if (enableGoogleNative) {
						NaCl_Development ();
				}
		}

		[UnityEditor.MenuItem (kRelease + "/All")]
		public static void AllBuildReleas ()
		{
				if (enableMac) {
						Mac86_Release ();
						Mac64_Release ();
						MacUniversal_Release ();
				}
				if (enableLinux) {
						Linux86_Release ();
						Linux64_Release ();
						LinuxUniversal_Release ();
				}
				if (enableWindows) {
						Win86_Release ();
						Win64_Release ();
				}
				if (enableWebPlayer) {
						WebPlayerDefault_Release ();
						WebPlayerOffline_Release ();
						WebPlayerStream_Release ();
						WebPlayerNaCL_Release ();
				}
				if (enableiPhone) {
						iOS_Release ();
				}
				if (enableAndroid) {
						Android_Release ();
				}
				if (enableBlackBerry) {
						BlackBerry_Release ();
				}
				if (enableMetro) {
						Metro_Release ();
				}
				if (enableWindowsPhone8) {
						WindowsPhone8_Release ();
				}
				if (enableGoogleNative) {
						NaCl_Release ();
				}
		}

		public static void ExportAssetAllPlatform (string resFolder)
		{
				if (enableMac) {
						AssetExport.Build (kAssetBundle + kMac86, resFolder, BuildTarget.StandaloneOSXIntel); 
						AssetExport.Build (kAssetBundle + kMac64, resFolder, BuildTarget.StandaloneOSXIntel64); 
						AssetExport.Build (kAssetBundle + kMacUniversal, resFolder, BuildTarget.StandaloneOSXUniversal);
				}
				if (enableLinux) {
						AssetExport.Build (kAssetBundle + kLinux86, resFolder, BuildTarget.StandaloneLinux); 
						AssetExport.Build (kAssetBundle + kLinux64, resFolder, BuildTarget.StandaloneLinux64); 
						AssetExport.Build (kAssetBundle + kLinuxUniversal, resFolder, BuildTarget.StandaloneLinuxUniversal);
				}
				if (enableWindows) {
						AssetExport.Build (kAssetBundle + kWindows86, resFolder, BuildTarget.StandaloneWindows); 
						AssetExport.Build (kAssetBundle + kWindows64, resFolder, BuildTarget.StandaloneWindows64);
				}
				if (enableWebPlayer) {
						AssetExport.Build (kAssetBundle + "/" + kWebPlayer, resFolder, BuildTarget.WebPlayer); 
						AssetExport.Build (kAssetBundle + "/" + kWebPlayer, resFolder, BuildTarget.WebPlayerStreamed); 
				}
				if (enableiPhone) {
						AssetExport.Build (kAssetBundle + "/" + kiOS, resFolder, BuildTarget.iPhone); 
				}
				if (enableAndroid) {
						AssetExport.Build (kAssetBundle + "/" + kAndroid, resFolder, BuildTarget.Android); 
				}
				if (enableBlackBerry) {
						AssetExport.Build (kAssetBundle + "/" + kBlackBerry, resFolder, BuildTarget.BB10); 
				}
				if (enableMetro) {
						AssetExport.Build (kAssetBundle + "/" + kMetro, resFolder, BuildTarget.MetroPlayer); 
				}
				if (enableWindowsPhone8) {
						AssetExport.Build (kAssetBundle + "/" + kWindowsPhone8, resFolder, BuildTarget.WP8Player); 
				}
				if (enableGoogleNative) {
						AssetExport.Build (kAssetBundle + "/" + kGoogleNative, resFolder, BuildTarget.NaCl); 
				}
		}

		[MenuItem (kAssetBundle + "/" + kMapChip)]
		public static void ExportMapChip ()
		{
				ExportAssetAllPlatform (kMapChip);
		}

		[MenuItem (kAssetBundle + "/" + kMagician)]
		public static void ExportMagician ()
		{
				ExportAssetAllPlatform (kMagician);
		}

		[MenuItem (kAssetBundle + "/" + kPrefab)]
		public static void ExportPrefab ()
		{
				ExportAssetAllPlatform (kPrefab);
		}

		[MenuItem (kAssetBundle + "/" + kSystem)]
		public static void ExportSystem ()
		{
				ExportAssetAllPlatform (kSystem);
		}

		[MenuItem (kAssetBundle + "/" + "ALL")]
		static void ExportALL ()
		{
				ExportMapChip ();
				ExportSystem ();
				ExportMagician ();
				ExportPrefab ();
		}
}

