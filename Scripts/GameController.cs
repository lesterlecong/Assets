using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

	public static GameController current;
	public BirdSpawner birdSpawner;
	public Text scoreText;
	public Text gameOverText;

	private int score = 0;
	private int previousGameLevel = 5;
	private bool isGameOver = false;
	private static bool isPaused = false;


	void Awake(){
		if (current == null) {
			current = this;
		} else if (current != this) {
			Destroy(gameObject);
		}
		gameOverText.enabled = false;
	}

	void Update(){
		if (isGameOver && Input.anyKey) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void Start () {

	}
	

	public void PlayerScored(){
		if (isGameOver) {
			return;
		}

		score++;

		if (score >= (previousGameLevel + 2)) {
			birdSpawner.increaseGameLevel();
			previousGameLevel = score;
		}


		scoreText.text = "Score: " + score.ToString();
	}

	public void PlayerDied(){
		birdSpawner.StopSpawn ();
		isGameOver = true;
		gameOverText.enabled = true;

	}

	public void Pause(){
		isPaused = true;
	}

	public void Play(){
		isPaused = false;
	}

	public bool IsPaused(){
		return isPaused;
	}

}
