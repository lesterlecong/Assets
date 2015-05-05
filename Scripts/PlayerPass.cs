using UnityEngine;
using System.Collections;

public class PlayerPass : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GameController.current.PlayerScored ();
		}
	}
}
