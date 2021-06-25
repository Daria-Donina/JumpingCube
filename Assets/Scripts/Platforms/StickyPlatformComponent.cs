using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class StickyPlatformComponent : MovingPlatformComponent
{
	GameObject player;
	Transform startPlayerParent;
	private bool isSticked;

	public StickyPlatformComponent(Transform transform, 
		float movingSpeed, 
		Vector3 endPoint, 
		GameObject player) : base(transform, movingSpeed, endPoint)
	{
		this.player = player;
		startPlayerParent = player.transform.parent;

		Player.Respawned += Restart;
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
		//if (!isSticked)
		//{
		//	player.transform.SetParent(Transform);
		//	isSticked = true;
		//}

		player.transform.SetParent(Transform);
	}

	public override void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject == player)
		{
			StickOff();
		}
	}

	private void StickOff()
	{
		//if (isSticked)
		//{
		//	player.transform.parent = startPlayerParent;
		//	isSticked = false;
		//}

		player.transform.SetParent(startPlayerParent);
	}

	private void Restart(object sender, EventArgs args)
	{
		StickOff();
	}

	public override void Dispose()
	{
		StickOff();

		Player.Respawned -= Restart;
	}
}
