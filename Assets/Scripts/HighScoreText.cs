using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
	private Text text;
	

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "High " + PlayerPrefs.GetInt(Utils.HighScoreKey, 0) + "m";
	}
}
