using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	private float count = 0;
	private float speed = 1;
	public GameManager gameManager;

	public float Count
	{
		get { return count; }
		set { count = value; }
	}

	public float Speed
	{
		get { return speed; }
		set { speed = value; }
	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.IsGameOver)
		{
			return;
		}
		
		Vector3 position = transform.position;

		position.x = Mathf.Cos(count * Mathf.Deg2Rad) * 3;

		transform.position = position;

		count += speed;
		count = count % 360;
	}
}