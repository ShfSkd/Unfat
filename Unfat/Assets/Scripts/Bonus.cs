using UnityEngine;

public class Bonus : MonoBehaviour
{
	float throwForce = 5f;
	float multiplier = 1.2f;

	bool activateBonus;

	PlayerController playerController;

	private void Start()
	{
		playerController = FindObjectOfType<PlayerController>();
	}
	private void FixedUpdate()
	{
		ThrowDistance();
	}
	private void OnTriggerEnter(Collider other)
	{
		playerController._canMove = false;
		activateBonus = true;
	}
	void ThrowDistance()
	{
		//weight determines bonus distance
		if(activateBonus)
		{
			playerController.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwForce, ForceMode.Impulse);

			for (int weight = 0; weight < playerController._weight; weight++)
			{
				throwForce /= multiplier;
				print(throwForce);
			}
		}
	}
}
