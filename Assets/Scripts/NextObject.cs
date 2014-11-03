using UnityEngine;
using System.Collections;

public class NextObject : MonoBehaviour {

	Manager mgr;
	Vector3 spawnpoint;
	public int kamis, junks;
	public GameObject[] objects;
	public Texture[] textures;
	int next,nextnext;
	NextBox nxb;

	// Use this for initialization
	void Start () {
		nxb = GameObject.Find ("GUI").GetComponent<NextBox> ();
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
		spawnpoint = GameObject.Find ("SpawnPoint").transform.position;
		OnStartNext ();
	}
	
	// Update is called once per frame
	void Update () {
		nxb.SetTexture (textures [next], textures [nextnext]);
	}

	//ボタンをおした時オブジェクトを新しくInstantiate
	public void Spawn(){
		GameObject obj =  Instantiate (objects [next], spawnpoint, objects [next].transform.rotation) as GameObject;
		obj.GetComponent<ButtonChecker> ().ptype = mgr.NextPaper ().type;
		Debug.Log (mgr.CurrentPaper ().type.ToString ());
		next = nextnext;
		mgr.GoNext ();
		//Next更新
		//紙判定．次の紙を生成
		if (mgr.NextNextPaper().type == Paper.Type.Normal) {
			nextnext = Random.Range (0, kamis);
		} else if (mgr.NextNextPaper ().type == Paper.Type.Junk) {
			nextnext = Random.Range (kamis+1, junks+kamis);
		}
	}

	void OnStartNext(){
		if (mgr.NextPaper ().type == Paper.Type.Normal) {
			next = Random.Range (0, kamis);
		} else if(mgr.NextNextPaper ().type == Paper.Type.Junk){
			next = Random.Range (kamis+1, kamis+junks);
		}
		if (mgr.NextNextPaper ().type == Paper.Type.Normal) {
			nextnext = Random.Range (0, kamis);
		} else if(mgr.NextNextPaper ().type == Paper.Type.Junk){
			nextnext = Random.Range (kamis+1, kamis + junks);
		}
		Debug.Log("initial next: "+next.ToString()+" nextnext : "+nextnext.ToString()); 
	}

}
