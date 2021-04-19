using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum DestroyOptions
{
	JumpNumber,
	TimeInSeconds,
	None
}

public class Platform : MonoBehaviour
{
	[SerializeField] private bool isMoving;
	[SerializeField] private float speed;
	private Vector3 endPoint;

	[Space]
 
	[SerializeField] private bool isSticky;

	[Space]

	[SerializeField] private DestroyOptions destroyOption;
	[SerializeField] private int jumpNumber;
	[SerializeField] private float timeInSeconds;

	[Space]

	[SerializeField] private bool isFading;
	[SerializeField] private float disabledTime;
	[SerializeField] private float activeTime;

	private GameObject player;
	private float time = 0f;
	private Vector3 startPoint;


	private void Start()
	{
		startPoint = transform.position;

		if (isMoving)
		{
			endPoint = transform.GetChild(0).position;
		}

		player = GameObject.FindGameObjectWithTag("Player");

		// Recalculate speed for current distance between start and end point
		var heading = startPoint - endPoint;
		var distance = heading.magnitude;
		speed /= (distance / 5);

		// поддержка исчезновения и появления
		if (isFading)
		{
			InvokeRepeating("SwitchExistence", activeTime, disabledTime);
		}
	}

	private void FixedUpdate()
	{
		if (isMoving)
		{
			Move();
		}
	}

	private void Move()
	{
		time += speed * Time.deltaTime;
		var position = Mathf.PingPong(time, 1f);		

		transform.position = Vector3.Lerp(startPoint, endPoint, position);
	}

	private void SwitchExistence()
    {
		if (gameObject.activeInHierarchy)
        {
			StickOff(player);
        }
		gameObject.SetActive(!gameObject.activeInHierarchy);
    }

	private void OnTriggerEnter(Collider collider)
	{
		Debug.Log("Player: ", player);
		Debug.Log("go: ", collider.gameObject);
		if (collider.gameObject == player)
		{
			Debug.Log("player");
			if (isSticky)
			{
				StickOn(player);
				Invoke("Delay", .1f);
			}
		}		
	}

	private void StickOn(GameObject go) 
		=> go.transform.parent = transform;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == player)
		{
			if (destroyOption != DestroyOptions.None)
			{
				DestroyingOnCollisionEnter(collision);
			}
		}
	}

	private void DestroyingOnCollisionEnter(Collision collision)
	{
		switch (destroyOption)
		{
			case DestroyOptions.JumpNumber:
				jumpNumber -= 1;
				if (jumpNumber <= 0)
				{
					DestroyPlatform();
				}
				break;
			case DestroyOptions.TimeInSeconds:
				Invoke("DestroyPlatform", timeInSeconds);
				break;
			default:
				break;
		}
	}

	private void DestroyPlatform()
	{
		StickOff(player);
		Destroy(gameObject, 0.3f);
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject == player)
		{
			if (isSticky)
			{
				StickOff(player);
				Invoke("Delay", .01f);
			}
		}
	}

	private IEnumerable Delay()
    {
		yield return new WaitForSeconds(.5f);
    }

	private void StickOff(GameObject go) 
		=> go.transform.parent = null;
}
