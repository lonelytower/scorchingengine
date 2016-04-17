using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if((Physics.Raycast(this.transform.position,this.transform.forward,out hit,1))){
				hit.rigidbody.gameObject.SendMessage("Activate");
			}
		}
	}
}
