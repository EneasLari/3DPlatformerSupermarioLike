using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
	public string NextLevelScene; 

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.transform.gameObject.name.Equals ("Player")) {
			float x = GameObject.Find ("Player").transform.position.x - 5;
			float y = GameObject.Find ("Player").transform.position.y;
			float z = GameObject.Find ("Player").transform.position.z;
			GameObject.Find ("Player").transform.position = new Vector3 (x,y,z);
			GameObject.Find ("ButtonManager").GetComponent<SaveScript> ().save ();
			SceneManager.LoadScene (NextLevelScene);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
