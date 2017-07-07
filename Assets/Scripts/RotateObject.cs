using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
	public float speed=2;
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f,speed,0f,Space.World);//We use spaceword so we can be sure that is rotating correctly through world cords
	}
}
