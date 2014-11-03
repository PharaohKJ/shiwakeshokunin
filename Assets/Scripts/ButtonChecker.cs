using UnityEngine;
using System.Collections;

public class ButtonChecker : MonoBehaviour {
	public KeyCode buttonA,buttonB;
	public Vector3 b_shoot_force;
	bool ispressed;
	CheckPaper chp;
	MovePaper mvp;
	float shaketime;
	Manager mgr;
	NextObject nxtobj;
	public Paper.Type ptype;
	bool downlock;



	// Use this for initialization
	void Start () {
		downlock = false;
		shaketime = 2f;
		chp = gameObject.GetComponent<CheckPaper> ();
		mvp = gameObject.GetComponent<MovePaper> ();
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
		nxtobj = GameObject.Find ("SpawnManager").GetComponent<NextObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mgr.LimitTime() > 0) {
			if (Input.GetKeyDown (buttonA) && !ispressed && !mgr.IsJamming () && !downlock) {
				//ボタンAを押した時
				downlock = true;
				KeyDownA (this.gameObject);
				ispressed = true;
			} else if (Input.GetKeyDown (buttonB) && !ispressed && !mgr.IsJamming ()) {
				//ボタンBを押した時
				KeyDownB (this.gameObject);
				ispressed = true;
			}
			if (Input.GetKeyUp (buttonA)) {
				downlock = false;
			}

		}

	}

	//A押した時の関数
	void KeyDownA(GameObject targetobj){
		targetobj.AddComponent<Rigidbody> ();
		//重力オン
		targetobj.rigidbody.useGravity = true;
		//次の紙を生成
		nxtobj.Spawn ();
		Debug.Log ("Pressed A");
	}

	//B押した時の関数(ぶっとぶ)
	void KeyDownB(GameObject targetobj){
		//紙でなければrigidbody有効＆AddForeceでとばす
		Debug.Log (mgr.CurrentPaper ().type);
		if (ptype == Paper.Type.Junk) {
			//重力オン
			targetobj.AddComponent<Rigidbody> ();
			targetobj.rigidbody.useGravity = true;
			targetobj.rigidbody.AddForce (b_shoot_force);
			//次の紙を生成
			nxtobj.Spawn ();
			AudioManager.Instance.PlaySE("SE05_シュ");

		} else if(ptype == Paper.Type.Normal){
			//紙（正しい）の場合は飛ばして戻す
			//まず飛ばす設定
			targetobj.AddComponent<Rigidbody> ();
			targetobj.rigidbody.useGravity = true;
			Debug.Log ("shake");
			//shaketime中入力を拒否するコルーチン発動
			StartCoroutine (Shaking(targetobj,1.5f));

			AudioManager.Instance.PlaySE("uni1510_もっかい");
		}
		Debug.Log ("Pressed B");
	}

	//振ってもどすコルーチン
	IEnumerator Shaking(GameObject targetobj,float shoottime){
		targetobj.rigidbody.AddForce ((-1)*b_shoot_force);
		yield return new WaitForSeconds (shaketime-shoottime);
		targetobj.rigidbody.useGravity = false;
		targetobj.rigidbody.isKinematic = true;
		mvp.StartMove ();
		yield return new WaitForSeconds (shaketime);
		Destroy (targetobj.rigidbody);
		ispressed = false;
		//AudioManager.Instance.PlaySE("uni25 ごめんなさーい！");

		AudioManager.Instance.PlaySE("uni1510_もっかい");
	}
		
}
