using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNonDestroy : MonoBehaviour {

	public float XPos;
	public float YPos;
	public float ZPos;


	void Start(){
		XPos=transform.position.x;
		YPos=transform.position.y;
		ZPos=transform.position.z;
	}
	IEnumerator OnTriggerEnter(Collider col){
		transform.GetComponent<Collider>().isTrigger=false;
		if(col.gameObject.tag=="Player")
		{
			this.transform.position = new Vector3 (XPos,YPos+0.2f,ZPos);
			yield return new WaitForSeconds (0.08f);
			this.transform.position = new Vector3 (XPos,YPos,ZPos);
			yield return new WaitForSeconds (0.25f);
		}
		transform.GetComponent<Collider> ().isTrigger = true;
	}
}
