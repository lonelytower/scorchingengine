using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody playerRigidbody;
	Vector3 mousePos;
	Vector3 lookAtPos;
//	Vector3 prevMousePos;

    public float speed = 1f;
	// Use this for initialization
	void Start () {
			
		Cursor.lockState = CursorLockMode.Confined;
		playerRigidbody = GetComponent<Rigidbody>();
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newAngle = transform.rotation.eulerAngles;
		newAngle.z = 0;
		transform.eulerAngles = newAngle;
		mousePos = (Input.mousePosition);
//		Debug.Log(mousePos);
//		mousePos.z = 4;
//
//		lookAtPos = Camera.main.ScreenToWorldPoint(mousePos);
//
//		this.transform.LookAt(lookAtPos);

		if(mousePos.x < Screen.width/2-Screen.width/20){
			this.transform.Rotate(Vector3.up,-((Screen.width/2-mousePos.x)/100));
		}
		if(mousePos.x > Screen.width/2+Screen.width/20){
			this.transform.Rotate(Vector3.up,-((Screen.width/2-mousePos.x)/100));
		}
		if(mousePos.y < Screen.height/2-Screen.height/20){
			this.transform.Rotate(Vector3.left,-((Screen.height/2-mousePos.y)/100));
		}
		if(mousePos.y > Screen.height/2+Screen.height/20){
			this.transform.Rotate(Vector3.left,-((Screen.height/2-mousePos.y)/100));
		}

        if (Input.GetKey(KeyCode.W))
		{ 
			playerRigidbody.AddForce(transform.forward*speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
			playerRigidbody.AddForce((-(transform.right))*speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
			playerRigidbody.AddForce(transform.right*speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
			playerRigidbody.AddForce((-(transform.forward))*speed);
        }
    }
}
