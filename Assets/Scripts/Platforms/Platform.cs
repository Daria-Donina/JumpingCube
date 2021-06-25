using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public enum DestroyOptions
{
	AfterNJumps,
	AfterNSeconds
}

public class Platform : MonoBehaviour
{
	[SerializeField]
	private PlatformConfiguration configuration;

	private GameObject player;

	private List<PlatformComponent> components
		= new List<PlatformComponent>();
	private StickyPlatformComponent stickyComponent;
	private bool isVisible;

	public UnityEvent<GameObject> PlatformTouched;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Start()
	{

		if (configuration.Moving)
		{
			/// фиииикс плииииз
			var endPoint = transform.GetChild(0);

			if (configuration.Sticky)
			{
				stickyComponent = new StickyPlatformComponent(
					transform,
					configuration.MovingSpeed,
					endPoint.transform.position,
					player);
				components.Add(stickyComponent);
			}
			else
			{
				components.Add(new MovingPlatformComponent(
				transform,
				configuration.MovingSpeed,
				endPoint.transform.position));
			}
		}

		if (configuration.Destroying)
		{
			components.Add(new DestroyingPlatformComponent(
				this,
				configuration.DestroyOption,
				configuration.Amount,
				player));
		}

		// Fading Platform Component
		if (configuration.Fading)
		{
			InvokeRepeating(nameof(SwitchVisibility), configuration.ActiveTime, configuration.DisabledTime);
		}
	}

	public void SetVisible(bool state)
	{
		GetComponent<Renderer>().enabled = state;
		GetComponent<Collider>().enabled = state;

		isVisible = state;

		if (!state)
		{
			OnDestroy();
		}
	}

	public void DestroyPlatform()
	{
		SetVisible(false);
	}
	private void SwitchVisibility()
	{
		SetVisible(!isVisible);
	}

	private void FixedUpdate()
	{
		components.ForEach(component => component.Update());
	}


	private void OnTriggerEnter(Collider collider)
	{
		components.ForEach(component => component.OnTriggerEnter(collider));
	}

	private void OnCollisionEnter(Collision collision)
	{
		components.ForEach(component => component.OnCollisionEnter(collision));

		PlatformTouched.Invoke(gameObject);
	}

	private void OnTriggerExit(Collider collider)
	{
		components.ForEach(component => component.OnTriggerExit(collider));
	}

	private void OnDestroy()
	{
		components.ForEach(component => component.Dispose());
	}
}

