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

		transform.position = (_player.position - _distance) *Time.deltaTime;
	}
}
