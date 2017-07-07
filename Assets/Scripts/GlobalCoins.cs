using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCoins : MonoBehaviour {
	public GameObject CoinsText;
	public static int Coins;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CoinsText.GetComponent<Text> ().text =" x "+Coins;
	}
}
