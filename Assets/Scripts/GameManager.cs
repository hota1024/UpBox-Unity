using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PlayerController player;
	[SerializeField] private WallController wall;
	[SerializeField] private ObstacleGenerator obstacles;
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private GameObject gameUI;
	[SerializeField] private GameObject titleUI;

	private bool didGameOver;
	private bool isGameOver;
	private bool isTitle;

	public bool IsGameOver
	{
		get { return isGameOver; }
		set { isGameOver = value; }
	}

	public void Init()
	{
		isGameOver = false;
		didGameOver = false;
		isTitle = false;

		gameOverUI.SetActive(false);
		gameUI.SetActive(true);
		titleUI.SetActive(false);
	}

	// Use this for initialization
	void Start()
	{
		Init();
		isTitle = true;
		gameUI.SetActive(false);
		titleUI.SetActive(true);
		isGameOver = true;
	}

	public void Restart()
	{
		player.Init();
		wall.Init();
		obstacles.Init();
		Init();
	}

	// Update is called once per frame
	void Update()
	{
		if (player.IsHitedObstacle && didGameOver == false && isTitle == false)
		{
			isGameOver = true;
			didGameOver = true;
			gameOverUI.SetActive(true);
			gameUI.SetActive(false);
		}
	}
}