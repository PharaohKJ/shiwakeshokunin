using UnityEngine;
using System.Collections;

public class CheckPaper : MonoBehaviour {
	bool ispaper;
	Manager mgr;

	// Use this for initialization
	void Start () {
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
		//紙かどうか判定
		ispaper = Check ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//紙かどうかをチェックするメソッド
	//instantiate時に実行
	bool Check(){
		bool paper;
		if(mgr.CurrentPaper().type == Paper.Type.Normal){
			paper = true;
		}
		else{
			paper = false;
		}
			return paper;
	}

	//紙かどうか
	//True:紙
	//False:ジャンク
	public bool GetisPaper(){
		return ispaper;
	}


}
