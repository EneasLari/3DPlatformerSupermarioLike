using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMoveFirst : MonoBehaviour {

	public GameObject ActualMushroom;
	public GameObject ThisMushroom;

	void Update()
	{
		transform.parent = null;
		transform.Translate(Vector3.up * 2 * Time.deltaTime,Space.World);
		StartCoroutine(CloseAnim());
	}

	IEnumerator CloseAnim()
	{		
		yield return new WaitForSeconds (0.5f);
		Destroy (ThisMushroom);
		ActualMushroom.SetActive (true);
		
	}
}
