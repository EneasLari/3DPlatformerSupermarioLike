using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	public AudioSource CollectableAudio;//Einai pano sto keno gameobject ths cameras pou blepei ayta ta collectables
	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			GlobalCoins.Coins++;
			CollectableNamesList.collected.Add (gameObject.name);
			gameObject.GetComponent<Animator> ().enabled = true;
			CollectableAudio.Play ();
			Destroy (gameObject,0.195f);
			if (gameObject.name.Equals ("ActualMushroom")) {
				col.gameObject.transform.localScale += new Vector3 (0.3f,0.3f,0.3f);
			}
		}

	}
}
