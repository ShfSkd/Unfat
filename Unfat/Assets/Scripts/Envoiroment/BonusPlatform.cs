using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// set the Player in the middle of the flatform
public class BonusPlatform : MonoBehaviour
{
    [SerializeField] Transform _player;
	[SerializeField] float _speed = 5f;
	[SerializeField] GameObject[] _destroyOnFlatform;

	private void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.CompareTag("Player"))
		{
			Vector3 newZ = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			//var newZ = Vector3.MoveTowards(_player.transform.position, transform.position, _speed);
			 _player.transform.position = newZ;

			foreach (GameObject destroy in _destroyOnFlatform)
			{
				Destroy(destroy);
			}
		}
	}
}
