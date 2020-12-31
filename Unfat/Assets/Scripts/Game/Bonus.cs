using UnityEngine;

public class Bonus : MonoBehaviour
{
	[SerializeField] float throwForce = 5f;
	[SerializeField] float multiplier = 1.2f;

	[Tooltip("Time in seconds until next scene loads")] [SerializeField] float startingTime = 4f;
	float timer = 0;

	[HideInInspector] public bool activateBonus;
	bool forceAdded;

	PlayerController playerController;


	private void Start()
	{
		playerController = FindObjectOfType<PlayerController>();
		timer = startingTime;
	}
	private void Update()
	{
		BonusTimer();
	}
	private void FixedUpdate()
	{
		if (forceAdded) { return; }
		ThrowDistance();
	}
	private void OnTriggerEnter(Collider other)
	{
		playerController._canMove = false;
		activateBonus = true;

		playerController._anim.SetBool("Grounded", false);
	}
	void ThrowDistance()
	{
		//weight determines bonus distance
		if (activateBonus)
		{
			for (int weight = 0; weight < playerController._weight; weight++)
			{
				throwForce /= multiplier;
			}
			playerController.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
			forceAdded = true;
		}
	}
	void BonusTimer()
	{
		if (activateBonus)
		{
			timer -= Time.deltaTime;

			if (timer <= 0)
			{
				timer = startingTime;
				StartCoroutine(playerController.NextLevel());
			}
		}
	}
}
