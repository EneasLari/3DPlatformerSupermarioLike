using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBlockWithMushroom : MonoBehaviour {

	public GameObject Qblock;
	public GameObject DeadBlock;
	public GameObject Mushroom;

	IEnumerator OnTriggerEnter(Collider col){
		Qblock.SetActive (false);
		DeadBlock.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		if (Mushroom != null) {
			Mushroom.SetActive (true);
		} else 
		{
			Debug.Log ("To xtypises idi mia fora");
		}
	}
}
