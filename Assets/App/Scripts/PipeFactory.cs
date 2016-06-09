using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System;

public class PipeFactory : MonoBehaviour
{
	/// <summary>
	/// The pipe prefab.
	/// </summary>
	[SerializeField]
	private Pipe _pipePrefab;

	/// <summary>
	/// The duration of the move.
	/// </summary>
	[SerializeField]
	private float _moveDuration;

	/// <summary>
	/// The rotate second.
	/// </summary>
	[SerializeField]
	private float _cycleSecond;

	/// <summary>
	/// The time.
	/// </summary>
	[SerializeField]
	private float _time;

	/// <summary>
	/// The height margin.
	/// </summary>
	[SerializeField]
	private float _heightMargin;

	/// <summary>
	/// The pipe.
	/// </summary>
	private List<Pipe> _pipeList;

	/// <summary>
	/// The is start.
	/// </summary>
	private bool isStart;

	/// <summary>
	/// The on trigger enter handler.
	/// </summary>
	private Action _onTriggerEnterHandler;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize (Action onTriggerEnterHander)
	{
		_time = 0;
		isStart = false;
		_pipeList = new List<Pipe> ();
		_onTriggerEnterHandler = onTriggerEnterHander;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update ()
	{
		if (isStart == false) {
			return;
		}
		_time += Time.deltaTime;
		if (_time > _cycleSecond) {
			ShowPipe ();
			_time = 0;
		}
	}

	/// <summary>
	/// Shows the pipe.
	/// </summary>
	public void ShowPipe ()
	{
		Pipe p = CreatePipe ();
		p.Initialize (_onTriggerEnterHandler);
		p.transform.SetParent (transform, false);
		p.transform.localPosition = new Vector3 (0f, UnityEngine.Random.Range (-_heightMargin, _heightMargin)); 
		p.transform.DOLocalMoveX (-400f, _moveDuration).SetEase (Ease.Linear).OnComplete (() => {
			p.gameObject.SetActive (false);
		});
	}

	/// <summary>
	/// Starts the pipe.
	/// </summary>
	public void GameStart ()
	{
		isStart = true;
	}

	/// <summary>
	/// Games the over.
	/// </summary>
	public void GameOver ()
	{
		foreach (var p in _pipeList) {
			DOTween.Kill (p.transform);
		}
		isStart = false;
	}

	/// <summary>
	/// Creates the pipe.
	/// </summary>
	public Pipe CreatePipe ()
	{
		Pipe p = null;
		if (GetPipeFromPool (out p) == false) {
			p = Instantiate (_pipePrefab);	
			_pipeList.Add (p);
		}
		return p;
	}

	/// <summary>
	/// Gets the pipe from pool.
	/// </summary>
	/// <returns><c>true</c>, if pipe from pool was gotten, <c>false</c> otherwise.</returns>
	/// <param name="pipe">Pipe.</param>
	public bool GetPipeFromPool (out Pipe pipe)
	{
		pipe = null;
		if (_pipeList == null || _pipeList.Count == 0) {
			return false;
		}
		foreach (var p in _pipeList) {
			if (p.gameObject.activeSelf == false) {
				p.gameObject.SetActive (true);
				pipe = p;			
				return true;
			}
		}
		return false;
	}
}
