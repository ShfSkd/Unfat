using UnityEngine;

public class HealthyItem : MonoBehaviour
{
	[SerializeField] int _scoreToRemove = 100;
	ScoreHandler scoreHandler;

	private void Start()
	{
		scoreHandler = FindObjectOfType<ScoreHandler>();
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
