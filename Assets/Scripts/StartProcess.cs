using UnityEngine;
using System.Collections;

public class StartProcess : MonoBehaviour {
	Manager mgr;

	void Awake(){
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
		mgr.GameStart ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
