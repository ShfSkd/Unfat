using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
	[SerializeField] int score = 0;

	[SerializeField] Text scoreText;

	private void Start()
	{
		scoreText.text = score.ToString();
	}

	public void AddToScore(int addedScore)
	{

		if (score < 0) return;
		else
		{
			score += addedScore;
			scoreText.text = score.ToString();

		}
		
	}
	

}
