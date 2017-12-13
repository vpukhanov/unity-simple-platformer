using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour {

	public int Points { get; set; }

	public Text PointsText;

	// Use this for initialization
	void Start () {
		this.Points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPoints(int points) {
		this.Points += points;
		UpdateUI ();
	}

	private void UpdateUI() {
		PointsText.text = Points.ToString ();
	}
}
