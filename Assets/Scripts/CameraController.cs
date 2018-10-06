using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private GameObject target;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{
		
	}

	// Move to target
	void LateUpdate()
	{
		Vector3 position = transform.position;

		position.y = target.transform.position.y;

		transform.position = position;
	}
}