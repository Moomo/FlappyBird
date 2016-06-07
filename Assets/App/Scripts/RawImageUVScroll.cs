using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(RawImage))]
public class RawImageUVScroll : MonoBehaviour
{
	/// <summary>
	/// The raw image.
	/// </summary>
	[SerializeField]
	private RawImage _rawImage;

	/// <summary>
	/// The scroll ratio.
	/// </summary>
	[SerializeField]
	private float _scrollRatio;

	/// <summary>
	/// The is game start.
	/// </summary>
	[SerializeField]
	private bool _isGameStart;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize ()
	{
		_isGameStart = true;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		if (_isGameStart == false) {
			return;
		}
		_rawImage.uvRect = new Rect (Mathf.Repeat (Time.time * _scrollRatio, 1), 0, 1, 1);
	}

	/// <summary>
	/// Games the start.
	/// </summary>
	public void GameStart ()
	{
		_isGameStart = true;
	}

	/// <summary>
	/// Games the start.
	/// </summary>
	public void GameOver ()
	{
		_isGameStart = false;
	}
}