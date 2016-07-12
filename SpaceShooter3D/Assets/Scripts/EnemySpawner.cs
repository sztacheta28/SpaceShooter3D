using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;

	float shipBoundaryRadius = 0.5f;

	float spawnDistance = 1.5f;

	float enemyRate = 3f;
	float nextEnemy = 1f;
	
	void Update () {
		nextEnemy -= Time.deltaTime;

		if(nextEnemy <= 0f) {
			nextEnemy = enemyRate;
			enemyRate *= 0.95f;
			if(enemyRate < 0.80f)
				enemyRate = 0.80f;

			float max = 0.2f;
			float min = -0.2f;

			Vector3 pos = new Vector3(Random.Range(min, max), 0f, spawnDistance);

			int rnd = Random.Range(0, enemyPrefab.Length);

			GameObject enemyInstance = (GameObject)Instantiate(enemyPrefab[rnd], pos, Quaternion.identity);
			enemyInstance.transform.parent = transform;
			enemyInstance.transform.localPosition = pos;
			if(rnd == 0){
				enemyInstance.transform.localScale = new Vector3 (0.025f, 0.030f, 0.02f);
				foreach (Transform child in enemyInstance.transform)
				{
					child.localRotation = Quaternion.Euler(90f, 0f, 0f);
				}					
			}else if(rnd == 1){
				enemyInstance.transform.localScale = new Vector3 (0.017f, 0.013f, 0.025f);
			}else if(rnd == 2){
				enemyInstance.transform.localScale = new Vector3 (0.05f, 0.055f, 0.055f);
				foreach (Transform child in enemyInstance.transform)
				{
					child.localRotation = Quaternion.Euler(0f, -90f, 0f);
				}
			}else if(rnd == 3){
				enemyInstance.transform.localScale = new Vector3 (0.005f, 0.005f, 0.005f);
				foreach (Transform child in enemyInstance.transform)
				{
					child.localRotation = Quaternion.Euler(-90f, 90f, 0f);
				}
			}
		}
	}
}
