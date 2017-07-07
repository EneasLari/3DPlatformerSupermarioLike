using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEntry : MonoBehaviour {

	public GameObject pipeEntry;
	public int StoodOn;
	public GameObject MainCamera;
	public GameObject SecondCam;
	public GameObject Player;
	public AudioSource Pipesound;
	public Vector3 TeleportTo=new Vector3(12f,-2f,0.5f);
	public GameObject Fadescreen;
	public GameObject DisableWith;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name.Equals ("Player")) {
			StoodOn = 1;
			Debug.Log ("Lets GO");
		}
	}
	void OnTriggerExit(Collider col){
		Debug.Log ("Out of here");
		StoodOn = 0;
	}
	void Update(){
		if (Input.GetButtonDown ("GoDown")) {
			if (StoodOn == 1) {
				Debug.Log ("Down to pipe");
				StartCoroutine(WaitingForPipe());//Ektelese thn sunerthsei(Etsi orizete gia enumerators methodous)

			}
		}
	}
	IEnumerator WaitingForPipe()
	{
		Player.GetComponent<MYPlayerController>().enabled=false;
		Player.GetComponent<Animator>().enabled=false;
		Pipesound.Play ();
		Fadescreen.SetActive (true);
		pipeEntry.GetComponent<Animator>().enabled  = true;//energopoihse to animator
		yield return new WaitForSeconds (1.5f);//perimene  deutera
		Fadescreen.GetComponent<Animator>().enabled=true;
		MainCamera.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (0.495f);
		MainCamera.GetComponent<Animator> ().enabled = false;
		MainCamera.transform.GetChild (0).transform.GetChild(1).GetComponent<AudioSource> ().volume = 1;
		Fadescreen.GetComponent<Animator>().enabled=false;
		pipeEntry.GetComponent<Animator>().enabled  = false;//apenergopoihse ton animator
		SecondCam.SetActive (true);
		StoodOn = 0;
		MainCamera.SetActive (false);

		DisableWith.SetActive (false);//apenergopise oti sundeete amesa me thn kamera main kai den xreiazete

		Player.transform.position = TeleportTo;//metakoinise ton paixth sto meros pou tha thlemetaferthei
		Player.GetComponent<MYPlayerController>().enabled=true;
		Player.GetComponent<Animator>().enabled=true;
		Fadescreen.GetComponent<Animator>().enabled=true;
		yield return new WaitForSeconds (0.495f);
		Fadescreen.GetComponent<Animator> ().enabled = false;
		Fadescreen.SetActive (false);


	}
}
