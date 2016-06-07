using UnityEngine;
using System.Collections;
using System;

public class FlappyBird : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D _rigidBody;

	[SerializeField]
	private float _addForceY;

	/// <summary>
	/// The on collision enter handler.
	/// </summary>
	private Action _onCollisionEnterHandler;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize (Action onCollisionEnterHandler)
	{
		_onCollisionEnterHandler = onCollisionEnterHandler;
		_rigidBody.isKinematic = true;
	}

	/// <summary>
	/// Games the start.
	/// </summary>
	public void GameStart ()
	{
		_rigidBody.isKinematic = false;
	}

	/// <summary>
	/// Jump this instance.
	/// </summary>
	public void Jump ()
	{
		_rigidBody.velocity = Vector3.up * _addForceY;
		Debug.Log ("jump");
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	private void OnCollisionEnter2D (Collision2D collision)
	{
		Debug.Log ("enter");
		_onCollisionEnterHandler ();
	}
}
