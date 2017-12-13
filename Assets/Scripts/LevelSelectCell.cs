using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectCell : Tacticsoft.TableViewCell {

	private string levelPath;

	public Button StartLevelButton;

	public void Awake() {
		StartLevelButton.onClick.AddListener (StartLevel);
	}

	public void SetLevelName(string name) {
		StartLevelButton.GetComponentInChildren<Text> ().text = name;
	}

	public void SetLevelPath(string path) {
		levelPath = path;
	}

	private void StartLevel() {
		InterSceneData.LevelPath = levelPath;
		SceneManager.LoadScene ("Game Scene");
	}
}
