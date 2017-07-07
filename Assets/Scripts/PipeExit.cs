using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeExit : MonoBehaviour {

	public GameObject ExitPipeCollider;
	public GameObject CurrentCamera;
	public GameObject OtherCamera;
	public GameObject Player;
	public AudioSource Pipesound;
	public GameObject Fadescreen;
	public GameObject EnableWith;
	public GameObject DisableWith;

	IEnumerator OnTriggerEnter(Collider col){
		if (col.transform.gameObject.name.Equals ("Player")) {
			col.transform.gameObject.GetComponent<MYPlayerController> ().enabled = false;
			col.transform.gameObject.GetComponent<Animator> ().enabled = false;
			Pipesound.Play ();
			Fadescreen.SetActive (true);
			Fadescreen.GetComponent<Animator> ().enabled = true;
			yield return new WaitForSeconds (Pipesound.clip.length-0.1f);
			col.transform.gameObject.GetComponent<MYPlayerController> ().enabled = true;
			col.transform.gameObject.GetComponent<Animator> ().enabled = true;
			Fadescreen.GetComponent<Animator> ().enabled = false;

			EnableWith.SetActive (true);//energopise thn pista/antikeimena pou tha tilemetaferthei o paikths

			OtherCamera.SetActive (true);
			OtherCamera.transform.GetChild (0).transform.GetChild(2).GetComponent<AudioSource> ().volume = 1;//make music volume on again
			CurrentCamera.SetActive (false);
			Vector3 pos = ExitPipeCollider.transform.position;
			pos.y = 0f;
			Player.transform.position = pos;
			ExitPipeCollider.GetComponent<Animator> ().enabled = true;
			ExitPipeCollider.GetComponent<Animator> ().Play ("ExitPipe", 0, 0);
			Fadescreen.GetComponent<Animator> ().enabled = true;
			yield return new WaitForSeconds (0.495f);
			Fadescreen.GetComponent<Animator> ().enabled = false;
			yield return new WaitForSeconds (1);
			ExitPipeCollider.GetComponent<Animator> ().enabled = false;
			Fadescreen.SetActive (false);
			DisableWith.SetActive (false);
		}
	}
}
