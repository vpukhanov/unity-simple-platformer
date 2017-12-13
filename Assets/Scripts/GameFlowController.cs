using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
			SceneManager.LoadScene ("Level Select Scene");
		if (Input.GetKey (KeyCode.R))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
