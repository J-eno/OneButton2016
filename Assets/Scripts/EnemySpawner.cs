using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject spawner;
	public GameObject EnemyGo;
	//public float speed;
	public float maxSpawnRateInSeconds;
	// Use this for initialization
	void Start () 
	{
		if (spawner.tag == "RightSpawn") {
			maxSpawnRateInSeconds = 5;
		} 
		else 
		{
			maxSpawnRateInSeconds = Random.Range (6, 20);
		}
		
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		InvokeRepeating ("IncreaseSpawnRate", 0f, 12f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void SpawnEnemy()
	{
		GameObject anEnemy = (GameObject)Instantiate (EnemyGo);
		anEnemy.transform.position = spawner.transform.position;

		//Determines which way the Enemy should face on spawn
		if (anEnemy.transform.position.x == 17) 
		{
			anEnemy.transform.eulerAngles = new Vector3 (0, 0, 90);
		}
		else if (anEnemy.transform.position.x == -17) 
		{
			anEnemy.transform.eulerAngles = new Vector3 (0, 0, -90);
		}
		else if (anEnemy.transform.position.y == 10) 
		{
			anEnemy.transform.eulerAngles = new Vector3 (0, 0, 180);
		}
		else if (anEnemy.transform.position.y == -10) 
		{
			anEnemy.transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		ScheduleNextSpawn ();
	}

	void ScheduleNextSpawn()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 3f) {
			spawnInNSeconds = Random.Range (maxSpawnRateInSeconds, maxSpawnRateInSeconds + 10f);
		}
		else
		{
			spawnInNSeconds = 3f;
		}
		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 3f) 
		{
			maxSpawnRateInSeconds--;
		}
		if (maxSpawnRateInSeconds == 3f) 
		{
			CancelInvoke ("IncreaseSpawnRate");
		}
	}
		
}
