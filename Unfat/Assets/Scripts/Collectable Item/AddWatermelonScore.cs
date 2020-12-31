using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWatermelonScore : MonoBehaviour
{
	ScoreHandler handler;
	[SerializeField] int scoreToAdd = 100;

	private void Start()
	{
		handler = FindObjectOfType<ScoreHandler>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			handler.AddWatermelonScore(scoreToAdd);
			Destroy(gameObject);
		}
	}
}
