using UnityEngine;
using System.Collections;

public class Trash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision collision)
	{
		StartCoroutine( Wait(3.0f) );
	}
	
	private IEnumerator Wait(float time)
	{
		//yield return new WaitForSeconds(time);
		yield return new WaitForSeconds(time);
		this.gameObject.rigidbody.isKinematic = true;
		this.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}
	
	void OnBecameInvisible(){
        Destroy (this.gameObject);
    }
}
