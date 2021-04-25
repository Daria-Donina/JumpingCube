using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class StickyPlatformComponent : MovingPlatformComponent
{
	GameObject player;
	Transform playerParent;
	private bool isSticked;

	public StickyPlatformComponent(Transform transform, 
		float movingSpeed, 
		Vector3 endPoint, 
		GameObject player) : base(transform, movingSpeed, endPoint)
	{
		this.player = player;
		playerParent = player.transform.parent;
	}

	public override void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject == player)
		{
			StickOn();
		}
	}

	private void StickOn()
	{
		if (!isSticked)
		{
			player.transform.SetParent(Transform);
			isSticked = true;
		}
	}

	public override void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject == player)
		{
			StickOff();
		}
	}

	public void StickOff()
	{
		if (isSticked)
		{
			player.transform.parent = playerParent;
			isSticked = false;
			Debug.Log("stick off");
		}
	}
}
