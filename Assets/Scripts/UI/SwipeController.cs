using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IDragHandler, IEndDragHandler
{
	[SerializeField]
	private float percentThreshold = 0.2f;

	[SerializeField]
	private float easing = 0.5f;

	[SerializeField]
	private GameObject pagePanel;

	private Vector3 panelLocation;
	private PagePanelController pagePanelController;
	private int currentChild = 0;

	private float _spacing = 100 * Screen.height / Screen.width;
	private Vector3 _centerPosition;
	private HorizontalLayoutGroup layout;
	private Vector3 childWidth = Vector3.right;
	private Vector3 childHeight = new Vector3(0, 695, 0);

	public int CurrentChild
	{
		get => currentChild;
		set
		{
			currentChild = value;
			pagePanelController.SelectedNew(CurrentChild);
		}
	}

	private void Awake()
	{
		layout = GetComponent<HorizontalLayoutGroup>();
		layout.spacing = _spacing;
		childWidth *= transform.GetChild(0).GetComponent<RectTransform>().rect.width;

		_centerPosition = new Vector3(Screen.width / 2, Screen.height / 2, 10);
	}

	private void Start()
	{
		panelLocation = transform.position;
		pagePanelController = pagePanel.GetComponent<PagePanelController>();
	}

	public void Activate()
	{
		StartCoroutine(SmoothMove(transform.position, _centerPosition, easing));
	}

	public void OnDrag(PointerEventData eventData)
	{
		var difference = eventData.pressPosition.x - eventData.position.x;
		transform.position = panelLocation - new Vector3(difference, 0, 0);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		float percentage = (eventData.pressPosition.x - eventData.position.x)
			/ Screen.width;

		if (Mathf.Abs(percentage) >= percentThreshold)
		{
			var newLocation = panelLocation;

			if (percentage > 0 && CurrentChild < transform.childCount - 1)
			{
				newLocation += new Vector3(-Screen.width, 0, 0);
				CurrentChild++;
			}
			else if (percentage < 0 && CurrentChild > 0)
			{
				newLocation += new Vector3(Screen.width, 0, 0);
				CurrentChild--;
			}

			StartCoroutine(SmoothMove(transform.position, newLocation, easing));
			panelLocation = newLocation;
		}
		else
		{
			StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
		}
	}

	IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
	{
		var t = 0f;
		while (t <= 1.0)
		{
			t += Time.deltaTime / seconds;
			transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
			yield return null;
		}
	}
}
