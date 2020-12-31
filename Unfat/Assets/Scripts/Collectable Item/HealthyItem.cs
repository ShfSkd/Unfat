using UnityEngine;

//Decreases the player's weight(eating healthy food)
public class HealthyItem : MonoBehaviour
{
	[SerializeField] int _scoreToRemove = 100;
	ScoreWeightHandler scoreHandler;

	private void Start()
	{
		scoreHandler = FindObjectOfType<ScoreWeightHandler>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			scoreHandler.RemoveFromScore(_scoreToRemove);
			Destroy(gameObject);
		}
	}
}
