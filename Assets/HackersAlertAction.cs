using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text;

public class HackersAlertAction : MonoBehaviour {
	
		string Uname;
		string level;
		string sys;
		string post_URL;

		string postPath = "/hackers.php?";
//		public bool isMacOS = true;
//		public bool isWindowsOS = false;
//		bool node = false;
//		bool titleLeft = false;
//		bool titleMid = false;
//		bool titleRight = false;
//		void OnGUI(){
//				EditorGUILayout.BeginHorizontal();
//				{
//						// 小さいボタンで、さらに左右がぴったりつながる。
//						if( GUILayout.Button( "Left",EditorStyles.miniButtonLeft ) )
//						{
//								Debug.Log ( "Left" );
//						}
//						if( GUILayout.Button( "Mid",EditorStyles.miniButtonMid ) )
//						{
//								Debug.Log ( "Mid" );
//						}
//						if( GUILayout.Button( "Right",EditorStyles.miniButtonRight ) )
//						{
//								Debug.Log ( "Right" );
//						}
//				}
//				EditorGUILayout.EndHorizontal();
//				// 自分で切り替える必要あったりもする。
//				GUIStyle nodeStyle = node?(GUIStyle)"flow node hex 1 on":(GUIStyle)"flow node hex 1";
//				if( GUILayout.Button( "node",nodeStyle ) )
//				{
//						node = !node;
//				}
//		}
		// Use this for initialization
		void Start () {

				string filePath = "";
				if(Debug.isDebugBuild)
				{
						UnityEngine.Debug.Log (Application.platform);
				}
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
						// Windowsでの実行の場合.
						filePath = @"C:\HackersAlertAction\";
				}
				if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) {
						// OS Xでの実行の場合.
						filePath = "/Applications/HackersAlertAction/";
				}

				// Open the stream and read it back.
				getName (filePath);
				getLevel (filePath);
				getSys (filePath);

				string message = string.Concat("name=",Uname,"&level=",level);
				post_URL = sys + postPath + message;
				UnityEngine.Debug.Log ("HackersActionPost : " + post_URL);

				WWW www = new WWW(post_URL);
				StartCoroutine (Download(www));
		}

		IEnumerator Download(WWW www){
				yield return www;
		}

		void getName(string filePath){
				filePath = filePath + "alert_name.txt";
				using (FileStream fs = File.OpenRead(filePath)) 
				{
						using(StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
						{				
								Uname = sr.ReadLine();
								UnityEngine.Debug.Log (Uname);
						}
				}	
		}

		void getLevel(string filePath){
				filePath = filePath + "alert_level.txt";
				using (FileStream fs = File.OpenRead(filePath))  
				{
						using(StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
						{				
								level = sr.ReadLine();
								UnityEngine.Debug.Log (level);
						}
				}	
		}

		void getSys(string filePath){
				filePath = filePath + "alert_sys.txt";
				using (FileStream fs = File.OpenRead(filePath))  
				{
					
						using(StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
						{				
										sys = sr.ReadLine();
										UnityEngine.Debug.Log (sys);
						}
				}	
		}
	
		// Update is called once per frame
		void Update () {

		}
}
