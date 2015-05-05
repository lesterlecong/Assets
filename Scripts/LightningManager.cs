using UnityEngine;
using System.Collections;

public class LightningManager : MonoBehaviour {

	public Lightning lightningPrefab;
	public int numOfLightningInstance = 5;

	private Lightning[] lightningInstance;
	
	private static bool isLightningActivate = false;
	private Coroutine coroutine;
	private float powerTime;
	private BirdList birdListInstance;

	void Awake(){
		Debug.Log ("Lightning Manager Awake");
	}

	void Start(){
		Debug.Log ("Lightning Manager Start");
		lightningInstance = new Lightning[numOfLightningInstance];
		birdListInstance = BirdList.instance;
		birdListInstance.birdTargetList ().Clear ();
		InstantiateLightning ();
	}

	void InstantiateLightning(){
		for (int count = 0; count < numOfLightningInstance; count++) {
			Debug.Log("Instantiate Lightning");
			lightningInstance[count] = Instantiate(lightningPrefab);
			lightningInstance[count].gameObject.transform.parent = gameObject.transform;
			lightningInstance[count].gameObject.SetActive(false);
		}
	}

	public void strike(){
		if (birdListInstance.birdTargetList ().Count > 0) {
			GameController.current.Pause ();
			powerTime = 1;
			coroutine = StartCoroutine ("LightningSpawner");
			isLightningActivate = true;
		}
	}

	void Update(){

		if (isLightningActivate) {
			powerTime -= Time.deltaTime;

			if (powerTime <= 0) {
				powerTime = 1;
				isLightningActivate = false;
				GameController.current.Play ();
				StopLightning ();

			}
		}
	}

	IEnumerator LightningSpawner(){
		while (true) {
			if(birdListInstance == null){
				Debug.Log("birdlist instance is null");
				break;
			}

			for(int count = 0; count < numOfLightningInstance; count++){
				
				if(lightningInstance[count].gameObject.activeInHierarchy == false && birdListInstance.birdTargetList().Count > 0){

					lightningInstance[count].targetPosition(birdListInstance.birdTargetList () [0].transform.position);
					lightningInstance[count].gameObject.transform.position = gameObject.transform.position;
					lightningInstance[count].gameObject.SetActive(true);
				}
			}
			yield return null;
			
		}
	}

	void StopLightning(){

		if (coroutine != null) {
			StopCoroutine (coroutine);
			for (int count = 0; count < numOfLightningInstance; count++) {
				lightningInstance [count].gameObject.SetActive (false);
			}
		}
	}

}

