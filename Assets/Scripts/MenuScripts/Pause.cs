using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour {

	public GameObject pauseButton, pausePanel,WarningPanel;

	void Start () {
		OnUnpause ();
	}
	public void OnPause(){
		WarningPanel.SetActive (false);
		pausePanel.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0;
	}

	public void OnUnpause(){
		pausePanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;
	}
	public void BacktoMainMenu(){
		pausePanel.SetActive (false);
		WarningPanel.SetActive (true);
	}
	public void LoadMainMenuFromPause(){
		SceneManager.LoadScene ("Menu");
	}
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
	}
}
