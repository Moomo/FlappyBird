using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TitleRoot : MonoBehaviour
{
	[SerializeField]
	private Button _startButton;

	// Use this for initialization
	private	void Awake ()
	{
		Application.targetFrameRate = 60;
		_startButton.onClick.AddListener (() => {
			SceneManager.LoadScene ("Game");	
		});
	}
}
