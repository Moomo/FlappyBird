using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	[SerializeField]
	private Text _scoreText;

	public void Initialize ()
	{
		_scoreText.text = "0";		
	}

	/// <summary>
	/// Add this instance.
	/// </summary>
	public void Up ()
	{
		int currentScore = int.Parse (_scoreText.text);
		_scoreText.text = (currentScore + 1).ToString ();
	}
}
