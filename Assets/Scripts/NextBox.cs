using UnityEngine;
using System.Collections;

public class NextBox : MonoBehaviour {
	public float width,height;
	public Texture txnext,txnextnext;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width - width - 20, 10, width, height), "next box");
		GUI.Box (new Rect (Screen.width - width - 10, 40, 70, 70), txnext);
		GUI.Box (new Rect (Screen.width - width - 10, 120, 70, 70), txnextnext);
		GUI.Label(new Rect (Screen.width - width + 65, 60, 70, 70), "Next");
		GUI.Label(new Rect (Screen.width - width + 65, 140, 70, 70), "NextNext");
	}

	public void SetTexture(Texture next,Texture nextnext){
		txnext = next;
		txnextnext = nextnext;
	}
}
