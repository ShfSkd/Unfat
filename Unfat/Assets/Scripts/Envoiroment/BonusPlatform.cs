using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPlatform : MonoBehaviour
{
    [SerializeField] Transform _player;
    private BoxCollider _collider;

	private void Awake()
	{
		_collider = GetComponent<BoxCollider>();
	}
	private void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.CompareTag("Player"))
		{
			Vector3 newZ = new Vector3(transform.position.x, transform.position.y, target.collider.transform.position.z);
			 _player.transform.position = newZ;
		}
	}
}
