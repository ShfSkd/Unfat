using UnityEngine;

//Increases the player's weight(eating junk food)
public class UnhealthyItem : MonoBehaviour
{
	[SerializeField] int scoreToAdd = 100;
	ScoreWeightHandler scoreHandler;

	private void Start()
	{
		scoreHandler = FindObjectOfType<ScoreWeightHandler>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player") && scoreHandler!=null)
		{
			scoreHandler.AddToScore(scoreToAdd);
			Destroy(gameObject);
		}
	}

}
