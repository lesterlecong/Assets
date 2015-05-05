using UnityEngine;
using System.Collections;

public class LightningCreator : MonoBehaviour {

	public Lightning lightningPrefab;

	private Lightning[] lightningInstance;
	private int numOfLightningInstance = 5;
	private GameObject _targetObject = null;

	void Start () {
		lightningInstance = new Lightning[numOfLightningInstance];
		for (int count = 0; count < numOfLightningInstance; count++) {
			if(_targetObject != null){
					
			}

			lightningInstance[count] = Instantiate(lightningPrefab);
			lightningInstance[count].gameObject.transform.parent = gameObject.transform;
			lightningInstance[count].gameObject.SetActive(false);
		}

		StartCoroutine (LightningSpawner ());
	}

	public void SetLightningTarget(GameObject targetObject){
		_targetObject = targetObject;
	}

	IEnumerator LightningSpawner(){
		while (true) {

			for(int count = 0; count < numOfLightningInstance; count++){

				if(lightningInstance[count].gameObject.activeInHierarchy == false){
					lightningInstance[count].targetPosition(_targetObject.transform.position);
					lightningInstance[count].gameObject.transform.position = gameObject.transform.position;
				    lightningInstance[count].gameObject.SetActive(true);
				}
			}
			yield return null;

		}
	}
	
	
}
