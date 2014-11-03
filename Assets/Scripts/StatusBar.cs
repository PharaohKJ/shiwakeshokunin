using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour {

	public Manager manager;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.IsJamming()){	
			gameObject.renderer.material.color = Color.red;
		} else {
			gameObject.renderer.material.color = Color.green;
		}
	}
}
