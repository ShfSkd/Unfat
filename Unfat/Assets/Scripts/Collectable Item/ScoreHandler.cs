using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
	[SerializeField] int score = 0;

	[SerializeField] Text scoreText;

	public void AddToScore(int addedScore)
	{
		score += addedScore;
		scoreText.text = score.ToString();
	}
}
