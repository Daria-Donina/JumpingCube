using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	private Text field;
	protected virtual void Start()
	{
		field = GetComponent<Text>();
	}

	public void Display(string text)
	{
		field.text = text;
	}
}
