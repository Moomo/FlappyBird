using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Pipe : MonoBehaviour
{
	[SerializeField]
	private Image _upperPipe;
	[SerializeField]
	private Image _lowerPipe;
	[SerializeField]
	private float _margin;
	/// <summary>
	/// The on trigger enter handler.
	/// </summary>
	private Action _onTriggerEnterHandler;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize (Action onTriggerEnterHandler)
	{
		_onTriggerEnterHandler = onTriggerEnterHandler;
	}

	/// <summary>
	/// Raises the validate event.
	/// </summary>
	public void OnValidate ()
	{
		_upperPipe.rectTransform.localPosition = new Vector3 (0, 125f + _margin / 2, 0);	
		_lowerPipe.rectTransform.localPosition = new Vector3 (0, -125f - _margin / 2, 0);	
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnTriggerEnter2D (Collider2D other)
	{
		_onTriggerEnterHandler ();
	}
}
