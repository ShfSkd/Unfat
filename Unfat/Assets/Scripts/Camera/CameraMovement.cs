using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float _cameraSpeed = 7f;
	public Vector3 _cameraVelocity;

	[SerializeField] Transform player;
	[SerializeField] Vector3 offset;

	private void Update()
	{
		if (FindObjectOfType <PlayerController>()._canMove)
			transform.position += Vector3.forward * _cameraSpeed ;

		_cameraVelocity= Vector3.forward * _cameraSpeed ;

		transform.position = player.transform.position + offset;
	}
}
