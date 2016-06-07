using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class TapToStart : MonoBehaviour
{
	/// <summary>
	/// The tap to start image.
	/// </summary>
	[SerializeField]
	private Image _tapToStartImage;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize ()
	{
		DOTween.Sequence ()
		.Append (_tapToStartImage.DOFade (0.2f, 1.0f))
		.Append (_tapToStartImage.DOFade (1f, 1.0f))
		.Insert (0, _tapToStartImage.rectTransform.DOScale (0.8f, 1.0f))
		.Insert (1.0f, _tapToStartImage.rectTransform.DOScale (1f, 1.0f))
			.SetLoops (-1, LoopType.Restart);
	}

	/// <summary>
	/// Hide this instance.
	/// </summary>
	public void Hide ()
	{
		_tapToStartImage.enabled = false;
	}
}
