using UnityEngine;
using UnityEngine.SceneManagement;


// Handle the Scene Managment
public class SceneHandler : MonoBehaviour
{
	bool _isDead=false;
	private void Update()
	{
		if (_isDead) return;
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
		if (FindObjectOfType<PlayerController>()._dead)
		{
			Invoke("Restart", 2f);
			FindObjectOfType<PlayerController>().BreakPlayer();
			_isDead = true;
		}
	}
}
