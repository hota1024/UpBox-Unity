using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;

	public void Init()
	{
		transform.position = new Vector3(0, -10, 0);
	}

	// Use this for initialization
	void Start()
	{
		Init();
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.IsGameOver)
		{
			return;
		}
		
		Vector3 position = transform.position;

		position.y += 0.065f;

		transform.position = position;
	}
}