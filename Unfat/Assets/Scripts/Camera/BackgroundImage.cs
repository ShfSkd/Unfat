using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Changes color for each different level
public class BackgroundImage : MonoBehaviour
{
    private Color _randomColor;

	private void Start()
	{
		_randomColor=new Color(Random.Range(0.1f,1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
		GetComponent<SpriteRenderer>().color = _randomColor;
	}
}
