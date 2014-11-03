using UnityEngine;
using System.Collections;

public class MovePaper : MonoBehaviour {
	public float movetox,movetoy,movetoz,movetime;

	// Use this for initialization
	void Start () {
		StartMove ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartMove(){
		//GameObject(紙)がInstantiateされたとき上から下へと動かす
		iTween.MoveTo (gameObject,iTween.Hash("x",movetox,
			"y",movetoy,
			"z",movetoz,
			"time",movetime,
			"easeType",iTween.EaseType.easeInSine));
	}

	public void Shake(float times){
		iTween.ShakePosition (gameObject, iTween.Hash ("x",15));
	}


}
