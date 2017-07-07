using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

	public float v;
	public float h;
	public float run;
	Animator myAnimator;  

	// Use this for initialization
	void Start () {
		myAnimator=GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		v=Input.GetAxis("Vertical");
		h=Input.GetAxis("Horizontal");
		if (myAnimator.GetFloat("Run")==0.2f){
			if (Input.GetKeyDown("space")){
				myAnimator.SetBool("Jump",true);
			}
		}
		Sprinting();
	}

	void FixedUpdate(){
		myAnimator.SetFloat("Walk",v);
		myAnimator.SetFloat("Run",run);
		myAnimator.SetFloat("Turn",h);
	}

	void Sprinting(){
		if (Input.GetKey(KeyCode.LeftShift)){
			run=0.2f;
		}
		else
		{
			run=0.0f;
		}
	}
}
