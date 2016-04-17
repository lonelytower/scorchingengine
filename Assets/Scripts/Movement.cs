using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody playerRigidbody;
	Vector3 mousePos;
	Vector3 lookAtPos;
//	Vector3 prevMousePos;


	float deadzone = 60f;
	float sensitivity = 30f;
	float maxSpeed = 5f;
    public float speed = 10f;
	// Use this for initialization
	void Start () {
			
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
		playerRigidbody = GetComponent<Rigidbody>();
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
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

		if(mousePos.x < Screen.width/2-Screen.width/deadzone){
			this.transform.Rotate(Vector3.up,-((Screen.width/2-mousePos.x)/sensitivity));
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.lockState = CursorLockMode.None;
		}
		if(mousePos.x > Screen.width/2+Screen.width/deadzone){
			this.transform.Rotate(Vector3.up,-((Screen.width/2-mousePos.x)/sensitivity));
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.lockState = CursorLockMode.None;
		}
		if(mousePos.y < Screen.height/2-(Screen.height/deadzone)){
			this.transform.Rotate(Vector3.left,-((Screen.height/2-mousePos.y)/sensitivity));
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.lockState = CursorLockMode.None;
		}
		if(mousePos.y > Screen.height/2+Screen.height/(deadzone-38)){
			this.transform.Rotate(Vector3.left,-((Screen.height/2-mousePos.y)/sensitivity));
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.lockState = CursorLockMode.None;

		}
//		if(mousePos.x < Screen.width/2-Screen.width/deadzone){
//			this.transform.Rotate(Vector3.up,-(1/sensitivity));
//
//			Cursor.lockState = CursorLockMode.Locked;
//			Cursor.lockState = CursorLockMode.None;
//		}
//		if(mousePos.x > Screen.width/2+Screen.width/deadzone){
//			this.transform.Rotate(Vector3.up,(1/sensitivity));
//
//			Cursor.lockState = CursorLockMode.Locked;
//			Cursor.lockState = CursorLockMode.None;
//		}
//		if(mousePos.y < Screen.height/2-Screen.height/deadzone){
//			this.transform.Rotate(Vector3.left,-(1/sensitivity));
//			Cursor.lockState = CursorLockMode.Locked;
//			Cursor.lockState = CursorLockMode.None;
//		}
//		if(mousePos.y > Screen.height/2+Screen.height/(deadzone-38)){
//			this.transform.Rotate(Vector3.left,(1/sensitivity));
//			Cursor.lockState = CursorLockMode.Locked;
//			Cursor.lockState = CursorLockMode.None;
//		}



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
		if(!(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))){
			playerRigidbody.velocity = Vector3.zero;
		}

		if(playerRigidbody.velocity.magnitude > maxSpeed){
			float brakeSpeed = playerRigidbody.velocity.magnitude - maxSpeed;

			Vector3 normalisedVelocity = playerRigidbody.velocity.normalized;
			Vector3 brakeVelocity = normalisedVelocity*brakeSpeed; //

			playerRigidbody.AddForce(-brakeVelocity);
		}
    }
}
