using UnityEngine;
using System.Collections;

public class IslandSpawner : MonoBehaviour {

	public GameObject islandPrefab;
	public int islandPoolSize = 5;
	public float spawnRate = 3f;
	public float islandYPosMin = -1f;
	public float islandYPosMax = 3.5f;
	public float offset = 10f;

	GameObject[] islands;
	int currentIsland = 0;

	void Start () {
		islands = new GameObject[islandPoolSize];

		for (int index = 0; index < islandPoolSize; index++) {
			islands[index] = (GameObject)Instantiate(islandPrefab);
		}

		StartCoroutine ("SpawnLoop");
	}

	public void StopSpawn(){
		StopCoroutine ("SpawnLoop");
	}

	IEnumerator SpawnLoop(){
		while (true) {

			Vector3 pos = transform.position;
			pos.y = Random.Range(islandYPosMin, islandYPosMax);
			pos.x += offset;

			islands[currentIsland].transform.position = pos;

			if(++currentIsland >= islandPoolSize)
				currentIsland = 0;

			yield return new WaitForSeconds(spawnRate);
		}
	}
}
