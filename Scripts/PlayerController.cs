using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float upForce;
	public float forwardSpeed;
	public bool isDead = false;
	public GameObject smoke;

	bool flap = false;
	bool onTop = false;


	void Start(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (forwardSpeed, 0);
	}

	void Update(){
		if (isDead)
			return;

		if (Input.anyKeyDown)
			flap = true;
	}

	void FixedUpdate(){

		if (GameController.current.IsPaused ()) {
			GetComponent<Rigidbody2D> ().isKinematic = true;
		}else if(!GameController.current.IsPaused () ) {
			GetComponent<Rigidbody2D>().isKinematic = false;

			if(flap){
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (forwardSpeed, 0);

				flap = false;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0);
				if(!onTop){
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, upForce));
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Bird" || other.tag == "BirdGroup") {
			isDead = true;
			smoke.SetActive(true);
			smoke.GetComponent<Animator>().SetTrigger("smoke");
			GameController.current.PlayerDied();
		}
		if (other.tag == "TopBorder") {
			onTop = true;
		}


	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "TopBorder") {
			onTop = false;
		}
	}
}
