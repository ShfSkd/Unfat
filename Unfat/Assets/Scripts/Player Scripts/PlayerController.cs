using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float _speed = 5;
	[SerializeField] float _scale = .5f;
	[SerializeField] float _jumpForce = 20f;
	[SerializeField] float _verticalVelocity = 5f;
	[SerializeField] LayerMask _layerMask;

	[HideInInspector]
	public bool _canMove,_gameStart, _gameOver, _finish, _inAir,_superJump;
	[HideInInspector]
	public Animator _anim;

	public float _sensitivity = 0.16f;
	public float _clampDelta = 42f;
	public int _weight = 2;
	public int maxWeight = 5;
	public float _bounds = 5;
	public GameObject _breakablePlayer;


	private Rigidbody _rb;
	private Vector3 _lastMousePosition;
	private BoxCollider _collider;
	private GameManager _gameManager;



	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_anim = transform.GetChild(0).GetComponent<Animator>();
		_collider = GetComponent<BoxCollider>();
		_gameManager = GetComponent<GameManager>();
	}

	private void Start()
	{
		_inAir = false;
	}
	private void Update()
	{
		if (!PlayerManager.isGameStarted) return;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_bounds, _bounds), transform.position.y, transform.position.z);

		if (_canMove)
			transform.position += FindObjectOfType<CameraMovement>()._cameraVelocity;

		if (!_canMove && _gameOver)
		{
			if (Input.GetMouseButtonDown(0))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				Time.timeScale = 1f;
				Time.fixedDeltaTime = Time.timeScale * 0.02f;
			}
		}
		else if (!_canMove && !_finish)
		{
			if(FindObjectOfType<Bonus>().activateBonus) { return; }
			if (Input.GetMouseButtonDown(0))
			{
				FindObjectOfType<GameManager>().RemoveUI();
				_canMove = true;
			}
		}
		WeightControl();
	}
	private void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(0))
			_lastMousePosition = Input.mousePosition;

		Move();
	}

	public void Move()
	{
		if (_canMove)
		{
			if (Input.GetMouseButton(0))
			{
				Vector3 pos = _lastMousePosition - Input.mousePosition;
				pos = new Vector3(pos.x, 0f, pos.y);
				_lastMousePosition = Input.mousePosition;

				_anim.SetBool("Grounded", true);
				Vector3 moveForce = Vector3.ClampMagnitude(pos, _clampDelta);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
				_rb.AddForce(-moveForce * _sensitivity - (_rb.velocity / _speed)/2, ForceMode.VelocityChange);
=======
				_rb.AddForce(-moveForce * _sensitivity - _rb.velocity / speed, ForceMode.VelocityChange);
>>>>>>> Stashed changes
=======
				_rb.AddForce(-moveForce * _sensitivity - _rb.velocity / speed, ForceMode.VelocityChange);
>>>>>>> Stashed changes
=======
				_rb.AddForce(-moveForce * _sensitivity - _rb.velocity / speed, ForceMode.VelocityChange);
>>>>>>> Stashed changes
=======
				_rb.AddForce(-moveForce * _sensitivity - _rb.velocity / _speed, ForceMode.VelocityChange);
>>>>>>> parent of d8e1053... Take 4
=======
				_rb.AddForce(-moveForce * _sensitivity - (_rb.velocity / _speed)/2, ForceMode.VelocityChange);
>>>>>>> parent of f75f5c2... yalla 2
			}

		}
		else if (!IsGrounded())
		{
			_anim.SetBool("Grounded", false);

		}
		_rb.velocity.Normalize();
	}

	void GainWeight(int weight)
	{
		_weight += weight;
	}
	void LoseWeight(int weight)
	{
		_weight -= weight;
	}
	public void WeightControl()
	{
		//high weight increases mass and scale
		int clampWeight = Mathf.Clamp(_weight, 0, maxWeight);
		_weight = clampWeight;
		var scaleIncrease = new Vector3(_scale, _scale, _scale);
		switch (_weight)
		{
			case 0:
				_speed = 10;
				ScaleController(_scale * 0.8f);
				break;
			case 1:
				_speed = 20;
				ScaleController(_scale * 0.9f);
				break;
			case 3:
				_speed = 30;
				ScaleController(_scale * 1.25f);
				break;
			case 4:
				_speed = 40;
				ScaleController(_scale * 1.6f);
				break;
			case 5:
				_speed = 50;
				ScaleController(_scale * 2f);
				break;
			default:
				_speed = 30;
				ScaleController(_scale) ;
				break;
		}
	}
	void ScaleController(float scale)
	{
		transform.localScale = new Vector3(scale, scale, scale);
	}
	public IEnumerator NextLevel()
	{
		_finish = true;
		_canMove = false;
		_anim.SetTrigger("Dance");
		PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
		yield return new WaitForSeconds(0f);
		SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
	}

	private void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.CompareTag("Gain"))
		{
			if (!_gameOver && _weight == maxWeight)
				GameOver();
			else
			{
				GainWeight(1);
				Destroy(target.gameObject);
			}
		}
		else if (target.gameObject.CompareTag("Lose"))
		{
			LoseWeight(1);
			Destroy(target.gameObject);
		}
		if (target.gameObject.tag == "Finish")
		{
			StartCoroutine(NextLevel());
		}
	}
	private void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.tag == "Trampoline" )
		{
			Jump();
			_anim.SetBool("Grounded", IsGrounded());
			_inAir = false;
		}
	}

	private void Jump()
	{
		_anim.SetTrigger("Jump");
		_rb.velocity = new Vector3(0f, _jumpForce * _verticalVelocity, 2f);
		_anim.SetBool("Grounded", IsGrounded());
		_inAir = true;

	}

	private bool IsGrounded()
	{
		RaycastHit hit;
		Physics.Raycast(_collider.bounds.center, Vector3.down, out hit, Mathf.Infinity + 5f, _layerMask);
		Color rayColor;

		if (hit.collider != null)
		{
			rayColor = Color.green;
		}
		else
		{
			rayColor = Color.red;
		}

		Debug.DrawRay(_collider.bounds.center, Vector3.down * (Mathf.Infinity + 5f), rayColor);
		Debug.Log(hit.collider);
		return hit.collider != null;

	}

	private void GameOver()
	{
		GameObject brokenSphere = Instantiate(_breakablePlayer, transform.position, Quaternion.identity);

		foreach (Transform o in brokenSphere.transform)
		{
			// Slow Motion In death
			o.GetComponent<Rigidbody>().AddForce(Vector3.forward * _rb.velocity.magnitude, ForceMode.Impulse);
		}

		_canMove = false;
		_gameOver = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		gameObject.SetActive(false);

		Time.timeScale = 0.3f;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
