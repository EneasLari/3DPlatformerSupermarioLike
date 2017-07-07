using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemy : MonoBehaviour {
	public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 lookAt = Player.position;
		lookAt.x = transform.position.x;
		transform.LookAt (lookAt);
	}
}
