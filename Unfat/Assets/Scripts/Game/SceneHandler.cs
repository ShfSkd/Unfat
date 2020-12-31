using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	bool isDead=false;
	private void Update()
	{
		if (isDead) return;
		GameOver();
	}
	public void LoadMainMenu()
	{
		SceneManager.LoadScene(1);
	}
	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Restart()
	{
		// Call it by string
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void GameOver()
	{
		if (FindObjectOfType<PlayerController>().dead)
		{
			Invoke("Restart", 2f);
			FindObjectOfType<PlayerController>().BreakPlayer();
			isDead = true;
		}
	}
}
