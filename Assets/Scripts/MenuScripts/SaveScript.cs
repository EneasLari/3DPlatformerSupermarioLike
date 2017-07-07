using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

public class SaveScript : MonoBehaviour {

	public void save(){
		//string path= Application.dataPath;
		//TextAsset txtAsset = (TextAsset)Resources.Load("save") as TextAsset;
		//string txtContent = txtAsset.text;
		//System.IO.File.WriteAllText (Application.persistentDataPath + "/" + "maze" + ".txt", txtContent, Encoding.UTF8);

		//System.IO.StreamReader file =  new System.IO.StreamReader(Application.persistentDataPath + "/" + "maze"+".txt",Encoding.UTF8);

		//string text="dfgdsjgvsdmkvf";
		//System.IO.StreamWriter writer = new StreamWriter(Application.persistentDataPath+"/Saves.txt"); (GIA KINITA)
		System.IO.StreamWriter writer = new StreamWriter(Application.dataPath+"/Saves.txt");
		writer.WriteLine ("Coins " + GlobalCoins.Coins);
		writer.WriteLine("Lifes "+GlobalLifes.lifes);
		writer.WriteLine("Score "+GlobalScore.Score);
		writer.WriteLine("Level "+gameObject.scene.name);
		writer.WriteLine("Position "+GameObject.Find("Player").transform.position);
		writer.WriteLine("Collected Items");
		foreach (string name in CollectableNamesList.collected) {
			writer.WriteLine(name);
		}
		writer.WriteLine("End of Collected Items");
		Debug.Log ("SAVED");
		writer.Close();

	}
}
