using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ScreenTap : MonoBehaviour,IPointerDownHandler
{
	/// <summary>
	/// The screen tap handler.
	/// </summary>
	private Action _screenTapHandler;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize (Action onScreenTap)
	{
		_screenTapHandler = onScreenTap;
	}

	/// <summary>
	/// Raises the pointer down event.
	/// </summary>
	/// <param name="data">Data.</param>
	public void OnPointerDown (PointerEventData data)
	{
		_screenTapHandler ();
	}
}
