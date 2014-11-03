using UnityEngine;
using System.Collections;

public class ShredderHole : MonoBehaviour {
	public GameObject trash;
	public GameObject parent;
	//public GameObject statusBar;
	
	private Vector3 trashPos;
	//private float rnd;
	private float rnd;
	private Vector3 rndPos;
	private Quaternion rndRot;
	private Jamprocess jprcs;
	private Manager mgr;

	
	// Use this for initialization
	void Start () {
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
		parent = GameObject.FindGameObjectWithTag("Shredder");
		jprcs = GameObject.Find ("JamManager").GetComponent<Jamprocess> ();
		//statusBar = GameObject.FindGameObjectWithTag("StatusBar");
		//statusBarMat = statusBar.GetComponent<Material>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Kami") {
			AudioManager.Instance.PlaySE("uni1498_出勤");
			
			iTween.ShakePosition(parent.gameObject, iTween.Hash("x", -1.0f));
			
			Destroy (other.gameObject);
			//スコア追加
			mgr.ShredSuccess ();
			
			// trashの位置をシュレッダーの高さより低くした値として、trashの生成
			/*
			trashPos = this.gameObject.transform.position + new Vector3 (0.0f, -2.0f, 0.0f);
			Instantiate (trash, trashPos, Quaternion.identity);
			*/			

			// trashの生成位置と角度をランダムにし、１００個生成
			int i;
			for (i = 0; i < 1; i++) {
				rnd = Random.Range(-1.0f, 1.0f);
				rndPos = this.gameObject.transform.position + new Vector3(2.0f * rnd, -2.0f, 0.0f);
				rnd = Random.Range(-1.0f, 1.0f);
				rndRot.eulerAngles = new Vector3(rnd * 30, rnd * 30, rnd * 30);
				Instantiate(trash, rndPos, rndRot);
			}
			
		}
		
		if (other.gameObject.tag == "Ibutsu") {
			iTween.ShakePosition(parent.gameObject, iTween.Hash("x", -2.0f));
			AudioManager.Instance.PlaySE("SE04_エラー音2");
			
			//Destroyしない
			other.gameObject.rigidbody.useGravity = false;
			other.gameObject.rigidbody.isKinematic = true;
			//ジャム開始
			OnJam (other.gameObject);
		}

	}
	
	void OnJam(GameObject gobj){
		//ジャム関数呼び出し
		jprcs.StartJam (gobj);
		//ジャム後の動作

	}
}
