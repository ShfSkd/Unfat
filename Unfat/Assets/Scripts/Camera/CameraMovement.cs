using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declares how will the camera follow the player
public class CameraMovement : MonoBehaviour
{
	public float _cameraSpeed = 7f;
	public Vector3 _cameraVelocity;

	[SerializeField] Transform player;
	public Vector3 offset;

	private void Update()
	{
		if (FindObjectOfType<PlayerController>()._dead) return;

		if (FindObjectOfType <PlayerController>()._canMove)
			transform.position += (Vector3.forward * _cameraSpeed)*Time.deltaTime ;

		_cameraVelocity = (Vector3.forward * _cameraSpeed) * Time.deltaTime * 100f;

		transform.position = player.transform.position + offset;
	}
}
