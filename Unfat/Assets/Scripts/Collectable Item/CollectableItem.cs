using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
	[SerializeField] int scoreToAdd = 100;
	ScoreHandler scoreHandler;

	private void Start()
	{
		scoreHandler = FindObjectOfType<ScoreHandler>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			scoreHandler.AddToScore(scoreToAdd);
			Destroy(gameObject);
		}
	}

}
