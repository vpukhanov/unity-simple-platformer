using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

	private GameObject GameManager;
	private GameManagerController GameManagerScript;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
		GameManagerScript = GameManager.GetComponent<GameManagerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			GameManagerScript.AddPoints (100);
			Destroy (gameObject);
		}
	}
}
