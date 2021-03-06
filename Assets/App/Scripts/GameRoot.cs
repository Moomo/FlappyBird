﻿using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRoot : MonoBehaviour
{
	/// <summary>
	/// Game state.
	/// </summary>
	public enum GameState
	{
		NONE,
		READY,
		GAME,
		OVER,
	}

	[SerializeField]
	private ScreenTap _screenTap;
	[SerializeField]
	private FlappyBird _flappyBird;
	[SerializeField]
	private PipeFactory _pipeFactory;
	[SerializeField]
	private TapToStart _tapToStart;
	[SerializeField]
	private RawImageUVScroll _uvScroll;
	[SerializeField]
	private Score _score;
	/// <summary>
	/// The state.
	/// </summary>
	private ReactiveProperty<GameState> _state;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake ()
	{
		_state = new ReactiveProperty<GameState> ();
		_screenTap.Initialize (OnScreenTap);	
		_flappyBird.Initialize (OnCollisionEnter);
		_pipeFactory.Initialize (OnTriggerEnter);
		_uvScroll.Initialize ();
		_tapToStart.Initialize ();
		_score.Initialize ();
		_state.Value = GameState.READY;
		//Stateを監視
		_state.Subscribe (state => {
			switch (_state.Value) {
			case GameState.READY:
				break;
			case GameState.GAME:
				break;
			case GameState.OVER:
				break;
			}
		});
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	private void OnCollisionEnter ()
	{
		_state.Value = GameState.OVER;
		_pipeFactory.GameOver ();
		_uvScroll.GameOver ();
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	private void OnTriggerEnter ()
	{
		_score.Up ();
	}

	/// <summary>
	/// Raises the screen tap event.
	/// </summary>
	private void OnScreenTap ()
	{
		switch (_state.Value) {
		case GameState.READY:
			_state.Value = GameState.GAME;
			_pipeFactory.GameStart ();
			_uvScroll.GameStart ();
			_flappyBird.GameStart ();
			_flappyBird.Jump ();
			_tapToStart.Hide ();
			break;
		case GameState.GAME:
			_flappyBird.Jump ();
			break;
		case GameState.OVER:
			SceneManager.LoadScene ("Title");
			break;
		}
	}
}