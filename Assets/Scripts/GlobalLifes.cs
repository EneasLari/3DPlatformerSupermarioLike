using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLifes : MonoBehaviour {
	public GameObject LifeText;
	public static int lifes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LifeText.GetComponent<Text> ().text = " x "+lifes;
	}
}
