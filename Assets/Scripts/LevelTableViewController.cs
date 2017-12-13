using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LevelTableViewController : MonoBehaviour, Tacticsoft.ITableViewDataSource {
	public LevelSelectCell m_cellPrefab;
	public Tacticsoft.TableView m_tableView;

	private List<KeyValuePair<string, string>> filesList;

	// Use this for initialization
	void Start () {
		// Находим директорию с уровнями 
		// В редакторе: папка Levels в корне Assets
		// В сборке: папка Levels рядом с .exe файлом
		string levelsPath = Application.dataPath;
		if (!Application.isEditor) {
			levelsPath += "/../";
		}
		levelsPath += "/Levels/";

		Debug.Log (levelsPath);

		// Проходим по файлам уровней
		DirectoryInfo levelsDirectory = new DirectoryInfo (levelsPath);
		filesList = new List<KeyValuePair<string, string>> ();
		foreach (FileInfo f in levelsDirectory.GetFiles("*.level")) {
			filesList.Add (new KeyValuePair<string, string> (Path.GetFileNameWithoutExtension(f.Name), f.FullName));
		}

		m_tableView.dataSource = this;
	}

	//Will be called by the TableView to know how many rows are in this table
	public int GetNumberOfRowsForTableView(Tacticsoft.TableView tableView) {
		return filesList.Count;
	}

	//Will be called by the TableView to know what is the height of each row
	public float GetHeightForRowInTableView(Tacticsoft.TableView tableView, int row) {
		return (m_cellPrefab.transform as RectTransform).rect.height;
	}

	//Will be called by the TableView when a cell needs to be created for display
	public Tacticsoft.TableViewCell GetCellForRowInTableView(Tacticsoft.TableView tableView, int row) {
		LevelSelectCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as LevelSelectCell;
		if (cell == null) {
			cell = (LevelSelectCell)GameObject.Instantiate(m_cellPrefab);
			cell.name = "LevelSelectCellInstance_" + row.ToString();
		}
		cell.SetLevelName (filesList [row].Key);
		cell.SetLevelPath (filesList [row].Value);
		return cell;
	}
}
