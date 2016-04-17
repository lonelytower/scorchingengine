using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Activate() {

		switch(SceneManager.GetActiveScene().name){

			case "Fields":
				SceneManager.LoadScene("Canyon");
				break;
			case "Canyon":
				SceneManager.LoadScene("Fields");
				break;
			default:
				break;
		}
	}
}
