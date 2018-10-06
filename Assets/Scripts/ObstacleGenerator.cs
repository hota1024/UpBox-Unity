using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	[SerializeField] private GameObject target;
	[SerializeField] private GameObject obstaclePrefab;
	[SerializeField] private GameManager gameManager;

	private GameObject lastObstacle;

	public void Init()
	{
		foreach ( Transform child in gameObject.transform )
		{
			GameObject.Destroy(child.gameObject);
		}
		GenerateObstacle(new Vector3(0, 4, 0));
	}


	// Use this for initialization
	void Start()
	{
		Init();
	}

	// Update is called once per frame
	void Update()
	{
		if (target.transform.position.y - 1 > lastObstacle.transform.position.y)
		{
			GenerateObstacle(new Vector3(0, lastObstacle.transform.position.y + 7, 0));
		}
	}

	void GenerateObstacle(Vector3 position)
	{
		GameObject obstacle = Instantiate(obstaclePrefab, transform);
		ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
		
		obstacle.transform.position = position;
		obstacleController.Count = Random.Range(0, 360);
		obstacleController.Speed = Random.Range(0.5f, 4f);
		obstacleController.gameManager = gameManager;

		lastObstacle = obstacle;
	}
}