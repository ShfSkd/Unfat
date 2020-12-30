using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;

	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;
	
	public Transform chaseTarget;
	
	private float savedTime;
	private float secondsBetweenSpawning;

	PlayerController _player;

	private void Awake()
	{
		_player = GetComponent<PlayerController>();
	}
	void Start () 
	{
		savedTime = Time.time;
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - savedTime >= secondsBetweenSpawning ) // is it time to spawn again?
		{
			MakeThingToSpawn();
			savedTime = Time.time; // store for next spawn
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
		}	
	}

	void MakeThingToSpawn()
	{
		if (!PlayerManager.isGameStarted) return;

		// create a new gameObject
		GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;

		// set chaseTarget if specified
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<FoodChaser>() != null))
		{
			clone.gameObject.GetComponent<FoodChaser>().SetTarget(chaseTarget);

			Destroy(clone, 1f);
		}
		

		
	}
}
