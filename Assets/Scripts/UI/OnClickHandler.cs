using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickHandler : MonoBehaviour
{
	[SerializeField] private GameObject panelToEnable;
	[SerializeField] private GameObject panelToDisable;

	public void EnablePanel()
	{
		panelToEnable.SetActive(true);
	}

	public void DisablePanel()
	{
		panelToDisable.SetActive(false);
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void LoadLevel()
	{
		Loader.LoadScene($"Level{GetComponentInChildren<Text>().text}");
	}

	public void Pause()
	{
		Time.timeScale = 0;
	}

	public void Resume()
	{
		Time.timeScale = 1;
	}

	public void Music()
	{
		var text = transform.parent.GetComponentInChildren<Text>().text;
		
		if (text.EndsWith("Off"))
		{
			transform.parent.GetComponentInChildren<Text>().text = "Music: On";
		}
		else if (text.EndsWith("On"))
		{
			transform.parent.GetComponentInChildren<Text>().text = "Music: Off";
		}
	}

	public void Sound()
	{
		var text = transform.parent.GetComponentInChildren<Text>().text;

		if (text.EndsWith("Off"))
		{
			transform.parent.GetComponentInChildren<Text>().text = "Sound: On";
		}
		else if (text.EndsWith("On"))
		{
			transform.parent.GetComponentInChildren<Text>().text = "Sound: Off";
		}
	}

	public void Home()
	{
		Loader.LoadScene("StartMenu");
	}

	public void Restart()
	{
		var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		player.Respawn();
	}
}
