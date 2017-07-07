using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNamesList : MonoBehaviour {
	//Script that can be added to a game object so we can initialize some saved parapetres of scene from a txtx file
	public static List<string> collected=new List<string>();
	// Use this for initialization
	void Start()
	{
		foreach(string s in collected)
		{
			//Destroy all object that are in this lests because they have been collected
			Destroy (GameObject.Find (s));
		}
		if(!(Load.PlayerSavedxyz[0]==-99999))
			gameObject.transform.position = new Vector3 (Load.PlayerSavedxyz [0], Load.PlayerSavedxyz [1], Load.PlayerSavedxyz [2]);
	}
}
