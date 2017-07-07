using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDisable : MonoBehaviour {
	public Transform Player;
	public float distanceFromPlayer=20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (Player.position, transform.position);
		Debug.Log (Vector3.Distance (Player.position, transform.position));
		if (dist < distanceFromPlayer) {
			gameObject.GetComponent<Renderer> ().enabled = true;
		} else {
			gameObject.GetComponent<Renderer> ().enabled = false;
		}
	}
}
