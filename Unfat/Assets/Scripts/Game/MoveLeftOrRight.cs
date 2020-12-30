using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftOrRight : MonoBehaviour
{
	public float _speed;
	public float _distance;

	private float _minX, _maxX;

	public bool _right, _dontMove;
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
	private void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.tag == "White" && target.gameObject.GetComponent<Rigidbody>().velocity.magnitude >1 || target.gameObject.name=="Player")
		{
			_stop = true;
			GetComponent<Rigidbody>().freezeRotation = false;
		}
	}
}
