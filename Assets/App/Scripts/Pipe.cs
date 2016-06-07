using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pipe : MonoBehaviour
{
	[SerializeField]
	private Image _upperPipe;
	[SerializeField]
	private Image _lowerPipe;
	[SerializeField]
	private float _margin;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	private void Initialize ()
	{
	}

	/// <summary>
	/// Raises the validate event.
	/// </summary>
	public void OnValidate ()
	{
		_upperPipe.rectTransform.localPosition = new Vector3 (0, 125f + _margin / 2, 0);	
		_lowerPipe.rectTransform.localPosition = new Vector3 (0, -125f - _margin / 2, 0);	
	}
}
