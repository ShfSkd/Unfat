using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Incharge of checking if the game began/finished.
public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool isGameStarted;

	private void Start()
	{
		gameOver = false;
		isGameStarted = false;
		Time.timeScale = 1f;
	}
	private void Update()
	{
		if (gameOver)
		{
			Time.timeScale = 0;
		}
		if (Input.GetMouseButtonDown(0))
		{
			isGameStarted = true;
		}
	}
}
