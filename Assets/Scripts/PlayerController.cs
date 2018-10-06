using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float gravity;
	[SerializeField] private float jumpPower;
	[SerializeField] private GameManager gameManager;
	
	private Vector3 velocity;
	private bool isHitedObstacle = false;

	public bool IsHitedObstacle
	{
		get { return isHitedObstacle; }
		set { isHitedObstacle = value; }
	}
	
	
	public void Init()
	{
		// Initialize velocity
		velocity = Vector3.zero;
		transform.position = new Vector3(0, 0, 0);
		isHitedObstacle = false;
	}

	// Use this for initialization
	void Start()
	{
		Init();
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(gameManager.IsGameOver);
		if (gameManager.IsGameOver)
		{
			return;
		}
		
		UpdateVelocity();
		UpdateJump();
		Move();
		UpdateHighScore();
	}

	void UpdateHighScore()
	{
		int high = PlayerPrefs.GetInt(Utils.HighScoreKey, 0);
		int score = (int)Mathf.Floor(transform.position.y);

		if (score > high)
		{
			PlayerPrefs.SetInt(Utils.HighScoreKey, score);
		}
	}

	// Update velocity
	void UpdateVelocity()
	{
		velocity.y -= gravity;
	}

	// Update jump
	void UpdateJump()
	{
		if (IsJumpKeyClicked())
		{
			velocity.y += jumpPower;
		}
	}

	// Move
	void Move()
	{
		Vector3 position = transform.position;
		
		// Reflect velocity
		position += velocity;
		
		transform.position = position;
	}

	// Judge jump key or touch
	bool IsJumpKeyClicked()
	{
		// Editor
		if (Input.GetKey(KeyCode.Space))
		{
			return true;
		}
		
		// Smart phone 
		if (Input.touchCount > 0)
		{
			return true;
		}
		
		return false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Obstacle" || other.tag == "Wall")
		{
			isHitedObstacle = true;
			Debug.Log("GameOver!");
		}
	}
}