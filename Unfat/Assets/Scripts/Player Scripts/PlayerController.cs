using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rb;
	private Vector3 _lastMousePosition;
	private Animator _anim;
	private BoxCollider _collider;

	public float _sensitivity = 0.16f;
	public float _clampDelta = 42f;
	public int _weight = 2;
	public int maxWeight = 5;

	[SerializeField] float speed = 5;
	[SerializeField] float scale = .5f;

	[SerializeField] LayerMask layerMask;


	public float _bounds = 5;

	[SerializeField] private float _jumpForce = 20f;

	[HideInInspector]
	public bool _canMove, _gameOver, _finish, _inAir;

	public GameObject _breakablePlayer;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_anim = transform.GetChild(0).GetComponent<Animator>();
		_collider = GetComponent<BoxCollider>();
	}

	private void Start()
	{
		_inAir = false;
	}
	private void Update()
	{
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
		if (Input.GetMouseButtonDown(0) && IsGrounded())
			_lastMousePosition = Input.mousePosition;

		if (_canMove)
		{
			if (Input.GetMouseButton(0))
			{
				Vector3 pos = _lastMousePosition - Input.mousePosition;
				_lastMousePosition = Input.mousePosition;
				pos = new Vector3(pos.x, 0f, pos.y);

				_anim.SetBool("Grounded", true);
				Vector3 moveForce = Vector3.ClampMagnitude(pos, _clampDelta);
				_rb.AddForce(-moveForce * _sensitivity - _rb.velocity / speed, ForceMode.VelocityChange);
			}
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
		var scaleIncrease = new Vector3(scale, scale, scale);
		switch (_weight)
		{
			case 0:
				speed = 10;
				ScaleController(scale * 0.8f);
				break;
			case 1:
				speed = 20;
				ScaleController(scale * 0.9f);
				break;
			case 3:
				speed = 30;
				ScaleController(scale * 1.25f);
				break;
			case 4:
				speed = 40;
				ScaleController(scale * 1.6f);
				break;
			case 5:
				speed = 50;
				ScaleController(scale * 2f);
				break;
			default:
				speed = 30;
				ScaleController(scale) ;
				break;
		}
	}
	void ScaleController(float scale)
	{
		transform.localScale = new Vector3(scale, scale, scale);
	}
	private IEnumerator NextLevel()
	{
		_finish = true;
		_canMove = false;
		PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
	}

	private void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.CompareTag("Enemy"))
		{
			if (!_gameOver && _weight == maxWeight)
				GameOver();
			else
			{
				GainWeight(1);
				Destroy(target.gameObject);
			}
		}
		else if (target.gameObject.CompareTag("White"))
		{
			LoseWeight(1);
			Destroy(target.gameObject);
		}

		if (target.gameObject.tag == "Trampoline" && IsGrounded())
		{
			Jump();
			_anim.SetBool("Grounded", true);
			_inAir = false;
		}
		if (target.gameObject.tag == "Finish")
		{
			StartCoroutine(NextLevel());
		}
	}

	private void Jump()
	{
		_rb.velocity = new Vector3(0f, _jumpForce * 0.5f, 0f);
		_anim.SetTrigger("Jump");
		_anim.SetBool("Grounded", false);
		_inAir = true;

	}

	private bool IsGrounded()
	{
		RaycastHit hit;
		Physics.Raycast(_collider.bounds.center, Vector3.down, out hit, Mathf.Infinity + 5f, layerMask);
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


	private void LoseWeight()
	{
		Transform scale = GetComponent<Transform>();


	}

	private void GameOver()
	{
		GameObject brokenSphere = Instantiate(_breakablePlayer, transform.position, Quaternion.identity);

		foreach (Transform o in brokenSphere.transform)
		{
			o.GetComponent<Rigidbody>().AddForce(Vector3.forward * _rb.velocity.magnitude, ForceMode.Impulse);
		}

		_canMove = false;
		_gameOver = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		Time.timeScale = 0.3f;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
