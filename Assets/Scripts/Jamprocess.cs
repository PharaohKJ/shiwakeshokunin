using UnityEngine;
using System.Collections;

public class Jamprocess : MonoBehaviour {

	public KeyCode buttonc;
	public int pushtimes;
	bool jaming;
	int button_counter;
	Manager mgr;
	GameObject gobj;


	// Use this for initialization
	void Start () {
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
		jaming = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (mgr.LimitTime () > 0) {
			if (jaming && Input.GetKeyDown (buttonc)) {
				button_counter++;
			}

			if (pushtimes == button_counter) {
				EndJam ();
			}  
		}
	}

	public void StartJam(GameObject gameobj){
		gobj = gameobj;
		mgr.Jam ();
		jaming = true;
	}

	void EndJam(){
		mgr.ClearJam ();
		Destroy (gobj);
		jaming = false;
		button_counter = 0;
	}
}
