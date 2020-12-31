using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBound : MonoBehaviour
{
	[SerializeField] Transform _player;
	[SerializeField] Vector3 _distance;

	private void Update()
	{
		if (!PlayerManager.isGameStarted) return;

		transform.position = new Vector3(transform.position.x, transform.position.y,Mathf.Clamp(transform.position.z,1f,-1f));
	}

}
