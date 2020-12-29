using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float _cameraSpeed = 7f;
	public Vector3 _cameraVelocity;

	private void Update()
	{
		if (FindObjectOfType <PlayerController>()._canMove)
			transform.position += Vector3.forward * _cameraSpeed ;

		_cameraVelocity= Vector3.forward * _cameraSpeed ;
	}
}
