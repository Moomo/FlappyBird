using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

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
		transform.DOLocalRotate (new Vector3 (0, 0, 30f), 0.5f);
		Debug.Log ("jump");
	}

	private void Update ()
	{
		if (_rigidBody.velocity.y < 0) {
			float currentAngleZ = transform.localEulerAngles.z;
			float addAngleZ = _rigidBody.velocity.y * 0.1f;
			float resultAngleZ = currentAngleZ + addAngleZ;
			if (resultAngleZ < 270f && currentAngleZ > 270f) {
				return;
			}
			transform.localRotation = Quaternion.Euler (0, 0, resultAngleZ);
		}
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
