using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml.Serialization;
using UnityEngine;

namespace XMLToCSharp {
	[XmlRoot(ElementName="Block")]
	public class Block {
		[XmlAttribute(AttributeName="Type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName="X")]
		public int X { get; set; }
		[XmlAttribute(AttributeName="Y")]
		public int Y { get; set; }
	}

	[XmlRoot(ElementName="Player")]
	public class Player {
		[XmlAttribute(AttributeName="X")]
		public int X { get; set; }
		[XmlAttribute(AttributeName="Y")]
		public int Y { get; set; }
	}

	[XmlRoot(ElementName="Exit")]
	public class Exit {
		[XmlAttribute(AttributeName="X")]
		public int X { get; set; }
		[XmlAttribute(AttributeName="Y")]
		public int Y { get; set; }
	}

	[XmlRoot(ElementName="Level")]
	public class Level {
		[XmlElement(ElementName="Block")]
		public List<Block> Blocks { get; set; }
		[XmlElement(ElementName="Player")]
		public Player Player { get; set; }
		[XmlElement(ElementName="Exit")]
		public Exit Exit { get; set; }
		[XmlAttribute(AttributeName="Name")]
		public string Name { get; set; }
	}
}

public class LevelBuilderController : MonoBehaviour {

	public GameObject PlayerObject;
	public GameObject ExitObject;

	public GameObject GroundPrefab;
	public GameObject GemPrefab;

	private DirectoryInfo levelsDirectory;

	void Awake() {
		XMLToCSharp.Level currentLevel = null;
		try {
			XmlSerializer serializer = new XmlSerializer(typeof(XMLToCSharp.Level));
			using (FileStream stream = new FileStream(InterSceneData.LevelPath, FileMode.Open)) {
				currentLevel = serializer.Deserialize(stream) as XMLToCSharp.Level;
			}
		} catch (Exception e) {
			Debug.Log (e.Message);
		}

		// ставим на место игрока и выход
		PlayerObject.transform.position = new Vector3 (currentLevel.Player.X, currentLevel.Player.Y, 0);
		ExitObject.transform.position = new Vector3 (currentLevel.Exit.X, currentLevel.Exit.Y, 1);

		// расставляем землю и камни
		foreach (XMLToCSharp.Block b in currentLevel.Blocks) {
			GameObject toInstantiate = null;
			switch (b.Type) {
			case "Ground":
				toInstantiate = GroundPrefab;
				break;
			case "Gem":
				toInstantiate = GemPrefab;
				break;
			}

			Instantiate (toInstantiate, new Vector3 (b.X, b.Y, 0), Quaternion.identity);
		}

		// активируем игрока и выход
		PlayerObject.SetActive(true);
		ExitObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
