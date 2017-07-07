using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void NewGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene(newGameLevel);
	}

	public void ExitGame(){
		Application.Quit ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
