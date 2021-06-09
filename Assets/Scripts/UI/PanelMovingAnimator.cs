using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelMovingAnimator : MonoBehaviour
{
	//[Header("Depended objects")]
	//[SerializeField] private Transform panelToMove;

	[Header("Configuration")]
	[SerializeField] private float moveDuration = 1f;

	[Tooltip("-1 to move from left side, 1 to move from right side")]
	[Range(-1, 1)]
	[SerializeField] 
	private int moveFrom;

	private Vector3 _centerPosition;
	private Vector3 _positionToShow;
	private Vector3 _positionToHide;

	private void Awake()
	{
		CalculatePosition();
	}

	public void Show()
	{
		transform.DOMove(_positionToShow, 0f);
		transform.DOMove(_centerPosition, moveDuration);
	}

	public void Hide()
	{
		transform.DOMove(_positionToHide, moveDuration);
	}

	private void CalculatePosition()
	{
		_centerPosition = new Vector3(Screen.width / 2, Screen.height / 2, 10);
		_positionToShow = _centerPosition + Vector3.right * Screen.width * 2 * moveFrom;
		_positionToHide = _centerPosition + Vector3.right * Screen.width * moveFrom;
	}
}
