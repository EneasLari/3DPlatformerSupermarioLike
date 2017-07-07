using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour {

	public float XPos;
	public float YPos;
	public float ZPos;
	public float wait = 0.02f;

	void Start(){
		XPos=transform.position.x;
		YPos=transform.position.y;
		ZPos=transform.position.z;
	}
	IEnumerator OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag=="Player")
		{
			transform.GetComponent<Collider>().isTrigger=false;
			this.transform.position = new Vector3 (XPos,YPos+0.1f,ZPos);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos+0.2f,ZPos);
			yield return new WaitForSeconds (wait);
			transform.GetComponent<Collider>().isTrigger=false;
			this.transform.position = new Vector3 (XPos,YPos+0.3f,ZPos+0.5f);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos+0.3f,ZPos+1.0f);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos-0.1f,ZPos+1.5f);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos-0.6f,ZPos+2.0f);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos-1.6f,ZPos+2.0f);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos-2.6f,ZPos+2.0f);
			yield return new WaitForSeconds (wait);
			this.transform.position = new Vector3 (XPos,YPos-4.6f,ZPos+2.0f);
			yield return new WaitForSeconds (0.25f);
			Destroy (gameObject);
		}
	}
}
