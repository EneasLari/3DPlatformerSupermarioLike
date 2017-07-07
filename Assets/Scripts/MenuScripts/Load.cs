using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {
	// Use this for initialization
	public static float[] PlayerSavedxyz=new float[3];

	//Just to check if tha players position should change in the collectablenamelist !!!!!!!!!!!!!!!!!!!
	void Start()
	{
		PlayerSavedxyz [0] = -99999;
	}

	public void LoadGame()
	{
		Debug.Log (Application.dataPath+"/Saves"+".txt");
		//C:\Users\eneas\AppData\LocalLow\DefaultCompany\SuperMarioClone (GIA KINITA)
		//System.IO.StreamReader file =  new System.IO.StreamReader(Application.persistentDataPath + "/" + "Saves"+".txt",Encoding.UTF8);
		System.IO.StreamReader file =  new System.IO.StreamReader(Application.dataPath+"/Saves"+".txt",Encoding.UTF8);


		string line = file.ReadLine ();
		if(line.Contains("Coins"))
		{
			String[] array = line.Split ();
			Debug.Log (array[1]);
			GlobalCoins.Coins = Int32.Parse (array [1]);
			line = file.ReadLine ();
		}
		if(line.Contains("Lifes"))
		{
			String[] array = line.Split ();
			GlobalLifes.lifes = Int32.Parse (array [1]);
			line = file.ReadLine ();
		}
		if(line.Contains("Score"))
		{
			String[] array = line.Split ();
			GlobalScore.Score = Int32.Parse (array [1]);
			line = file.ReadLine ();
		}
		if (line.Contains ("Level")) {
			String[] array = line.Split ();
			Debug.Log (array[1]);
			LoadBtn (array[1]);
			line = file.ReadLine ();
		}

		if (line.Contains ("Position")) {
			Char[] mytrims = {'(',',',')' };
			String[] array = line.Split ();
			int i = 0;
			foreach (string s in array) {
				Debug.Log ("OLD STRING="+s);
				if (!s.Equals ("Position")) {
					string trimed=s.Trim (mytrims);
					PlayerSavedxyz [i] = float.Parse (trimed);
					Debug.Log ("NEW STRING="+PlayerSavedxyz[i]);
					i++;

				}
			}
			//GameObject.Find ("Player").transform.position=new Vector3(xyz[0],xyz[1],xyz[2]);
			line = file.ReadLine ();
		}
		if(line.Contains("Collected Items"))
		{
			Debug.Log ("IAM IN COLLECTED COINS");
			line = file.ReadLine ();
			while (!line.Equals("End of Collected Items")) {
				//Add all the gameobjects that have been collected to the collected list so can be destroyed when the scene loads
				CollectableNamesList.collected.Add(line);
				line = file.ReadLine ();
			}
		}
		Debug.Log ("End Loading objects");
		file.Close ();
	}

	private void LoadBtn(string newGameLevel)
	{
		SceneManager.LoadScene(newGameLevel);
	}
}