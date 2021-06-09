using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
	[SerializeField]
	private float percentThreshold = 0.2f;

	[SerializeField]
	private GameObject pagePanel;

	[SerializeField]
	private float distanceBetweenPanels = 200f;

	[SerializeField]
	private float switchSpeed = 1f;

	private float panelLocationX;
	private PagePanelController pagePanelController;
	private int currentChild = 0;

	public int CurrentChild
	{
		get => currentChild;
		set
		{
			currentChild = value;
			pagePanelController.SelectedNew(CurrentChild);
		}
	}

	private void Start()
	{
		pagePanelController = pagePanel.GetComponent<PagePanelController>();
		SetDistanceBetweenPanels();
	}

	private void SetDistanceBetweenPanels()
	{
		int count = transform.childCount;

		for (int i = 0; i < count; i++)
		{
			Transform child = transform.GetChild(i);
			if (i == 0)
			{
				child.localPosition = Vector3.zero;
			}
			else
			{
				Transform lastChild = transform.GetChild(i - 1);
				var newPosition = new Vector3(distanceBetweenPanels, 0);
				newPosition += lastChild.localPosition;
				child.localPosition = newPosition;
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		var difference = eventData.pressPosition.x - eventData.position.x;
		var move = panelLocationX - difference;
		transform.DOLocalMoveX(move, 0f);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		float percentage = (eventData.pressPosition.x - eventData.position.x)
			/ distanceBetweenPanels;

		if (Mathf.Abs(percentage) >= percentThreshold)
		{
			if (percentage > 0 && CurrentChild < transform.childCount - 1)
			{
				panelLocationX -= distanceBetweenPanels;
				CurrentChild++;
			}
			else if (percentage < 0 && CurrentChild > 0)
			{
				panelLocationX += distanceBetweenPanels;
				CurrentChild--;
			}

			transform.DOLocalMoveX(panelLocationX, switchSpeed);
		}
		else
		{
			transform.DOLocalMoveX(panelLocationX, switchSpeed);
		}
	}
}
