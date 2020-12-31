using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Making the food move left/right on the platform
public class MoveLeftOrRight : MonoBehaviour
{
	[SerializeField] float _speed;
	[SerializeField] float _distance;
	[SerializeField] bool _right, _dontMove;

	private float _minX, _maxX;

	private bool _stop;

	private void Start()
	{
		_maxX = transform.position.x + _distance;
		_minX = transform.position.x - _distance;
	}
	private void Update()
	{
		if(!_stop && !_dontMove)
		{
			if (_right)
			{
				transform.position += Vector3.right * _speed * Time.deltaTime;
				if (transform.position.x >= _maxX)
					_right = false;
			}
			else
			{
				transform.position += Vector3.left * _speed * Time.deltaTime;
				if (transform.position.x <= _minX)
					_right = true;
			}
		}
	}
	private void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.tag == "Lose" && target.gameObject.GetComponent<Rigidbody>().velocity.magnitude >1 || target.gameObject.name=="Player")
		{
			_stop = true;
			GetComponent<Rigidbody>().freezeRotation = false;
		}
	}
}
