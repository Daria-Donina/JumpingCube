using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagePanelController : MonoBehaviour
{
	private int indexOfSelected = 0;
	private Color defaultColor = new Color(200 / 255f, 214 / 225f, 229 / 225f);
	private Color selectedColor = new Color(131 / 255f, 149 / 255f, 167 / 255f);

	private void Start()
	{
		var child = transform.GetChild(indexOfSelected);
		child.GetComponent<Image>().color = selectedColor;
	}

	public void SelectedNew(int index)
	{
		Debug.Log(index);

		var prevChild = transform.GetChild(indexOfSelected);
		prevChild.GetComponent<Image>().color = defaultColor;

		print(prevChild.name);

		var nextChild = transform.GetChild(index);
		nextChild.GetComponent<Image>().color = selectedColor;

		indexOfSelected = index;
	}
}
