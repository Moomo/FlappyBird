using UnityEngine;
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
	private RawImageUVScroll _uvScroll;
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
		_pipeFactory.Initialize ();
		_uvScroll.Initialize ();
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
