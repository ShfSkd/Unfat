using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Update watermelonScore
public class AddWatermelonScore : MonoBehaviour
{
	ScoreWeightHandler _handler;
	[SerializeField] int _scoreToAdd = 100;

	private void Start()
	{
		_handler = FindObjectOfType<ScoreWeightHandler>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_handler.AddWatermelonScore(_scoreToAdd);
			Destroy(gameObject);
		}
	}
}
