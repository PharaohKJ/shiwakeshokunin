using UnityEngine;
using System.Collections;

public class TitleView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayBGM("OP");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel("alpha");
		}
	}
}
