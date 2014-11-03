using UnityEngine;
using System.Collections;

public class Crend : MonoBehaviour {
	Manager mgr;
	public Texture renda;

	// Use this for initialization
	void Start () {
		mgr = GameObject.Find ("GlobalObject").GetComponent<Manager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (mgr.IsJamming()) {
			GUI.DrawTexture(new Rect(Screen.width*0.5f,Screen.height*0.5f,320f,180f),renda);
		}
	}
}
