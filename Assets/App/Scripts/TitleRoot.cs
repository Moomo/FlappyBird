using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleRoot : MonoBehaviour
{
	[SerializeField]
	private Button _startButton;

	// Use this for initialization
	private	void Awake ()
	{
		_startButton.onClick.AddListener (() => {
			SceneManager.LoadScene ("Game");	
		});
	}
}
