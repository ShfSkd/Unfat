using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEx : MonoBehaviour
{
    [SerializeField] GameObject _fx;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (_fx!=null)
			{
				Instantiate(_fx, transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
	}
}
