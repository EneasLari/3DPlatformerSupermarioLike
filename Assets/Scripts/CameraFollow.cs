using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform Player;
	public float DistanceFromPlayer=5f;
	public float StaticCameraY=3f;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame 
	void Update () {
		Vector3 pos = transform.position;
		pos.z = Player.position.z - DistanceFromPlayer;
		transform.position = pos;

		pos= transform.position;
		pos.x = Player.position.x;
		transform.position = pos;
	}

	void LateUpdate(){
		Vector3 pos = GetComponent<Camera> ().transform.position;
		pos.y=StaticCameraY;
		GetComponent<Camera> ().transform.position=pos;
	}
}
