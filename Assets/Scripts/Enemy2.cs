using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

	public float distanceFromPlayer;
	public float moveSpeed=4;
	public Transform Player;
	public Transform Target;
	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject Bullet_Emitter;
	public AudioSource destruction;
	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject Bullet;
	public AudioSource shoot;
	//Enter the Speed of the Bullet from the Component Inspector.
	public float Bullet_Forward_Force;
	private float nextFire=0f;
	public float fireRate = 0.5f;
	public int hitsTakenToDeath = 4;
	public GameObject DestroyedEnemy;

	bool looked=false;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (Target);//TO OPLO KOITA TON PAIXTH
		if (Vector3.Distance (Player.position, transform.position) < distanceFromPlayer && Vector3.Distance (Player.position, transform.position) > distanceFromPlayer/2) {
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			looked = true;
		}
		if (looked == true && Vector3.Distance (Player.position, transform.position) <= distanceFromPlayer/2) {
			Shoot ();
		}
		else if(looked == true && Vector3.Distance (Player.position, transform.position) > distanceFromPlayer)
		{
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		 
		if (hitsTakenToDeath <= 0) {
			GlobalScore.Score++;
			Destroy (gameObject.transform.FindChild("NormalEnemy").gameObject);
			DestroyedEnemy.SetActive(true);
			DestroyedEnemy.transform.SetParent(null);

			gameObject.GetComponent<Collider> ().enabled = false;
			gameObject.GetComponent<Enemy2> ().enabled=false;
			destruction.PlayOneShot (destruction.clip);
			Destroy (gameObject,destruction.clip.length);
		}
	}
	void OnCollisionEnter(Collision col){
		
		if (col.gameObject.name.Equals ("MyBullet(Clone)")) {
			
			Destroy (col.gameObject);
			hitsTakenToDeath--;
			Debug.Log ("Hits:"+hitsTakenToDeath);
		}
	}
	void Shoot()
	{
		if(Time.time>nextFire)
		{
			shoot.Play ();
			nextFire = Time.time + fireRate;
			//The Bullet instantiation happens here.
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_Bullet_Handler, 2.0f);
		}

	
	}
}
