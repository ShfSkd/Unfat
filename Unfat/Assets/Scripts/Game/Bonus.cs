using UnityEngine;



public class Bonus : MonoBehaviour
{
	public float _throwForce = 5f;
	[SerializeField] float _multiplier = 1.2f;

	[Tooltip("Time in seconds until next scene loads")] [SerializeField] float _startingTime = 4f;
	float _timer = 0;

	[HideInInspector] public bool _activateBonus;
	bool _forceAdded;

	PlayerController _playerController;


	private void Start()
	{
		_playerController = FindObjectOfType<PlayerController>();
		_timer = _startingTime;
	}
	private void Update()
	{
		BonusTimer();
	}
	private void FixedUpdate()
	{
		if (_forceAdded) { return; }
		ThrowDistance();
	}
	private void OnTriggerEnter(Collider other)
	{
		_playerController._canMove = false;
		_activateBonus = true;

		_playerController._anim.SetBool("Grounded", false);
	}

	// Declares how far will the player be thrown away(depends on the player's weight)
	void ThrowDistance()
	{
		//weight determines bonus distance
		if (_activateBonus)
		{
			for (int weight = 0; weight < _playerController._weight; weight++)
			{
				_throwForce /= _multiplier;
			}
			_playerController.GetComponent<Rigidbody>().AddForce(Vector3.forward * _throwForce, ForceMode.Impulse);
			_forceAdded = true;
		}
	}

	// Declares how long will it take to end the level
	void BonusTimer()
	{
		if (_activateBonus)
		{
			_timer -= Time.deltaTime;

			if (_timer <= 0)
			{
				_timer = _startingTime;
				StartCoroutine(_playerController.NextLevel());
			}
		}
	}
}
