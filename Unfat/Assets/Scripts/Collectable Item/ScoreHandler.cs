﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
	[SerializeField] int _score = 0;
	[SerializeField] int _maxScore = 100000;

	[SerializeField] Text scoreText;

	PlayerController player;

	private void Start()
	{
		player = FindObjectOfType<PlayerController>();
		scoreText.text = _score.ToString();
	}
	private void Update()
	{
		WeightController();
	}
	public void AddToScore(int addedScore)
	{
<<<<<<< Updated upstream
		_score += addedScore;
		scoreText.text = _score.ToString();
	}
	public void RemoveFromScore(int scoreRemoved)
	{
		int _clampedScore = Mathf.Clamp(_score, 80, _maxScore);
		_score = _clampedScore;
		_score -= scoreRemoved;
		scoreText.text = _score.ToString();
	}
	void WeightController()
	{
		switch (_score)
		{
			case 60:
				player._weight = 0;
				break;
			case 80:
				player._weight = 1;
				break;
			case 120:
				player._weight = 3;
				break;
			case 140:
				player._weight = 4;
				break;
			case 160:
				player._weight = 5;
				break;
			default:
				player._weight = 2;
				break;
		}
	}
=======

		if (score < 0) return;
		else
		{
			score += addedScore;
			scoreText.text = score.ToString();

		}
		
	}
	

>>>>>>> Stashed changes
}
