using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class DestroyingPlatformComponent : PlatformComponent
{
	private const float delayForJumpDestroy = 0.3f;

	private GameObject player;

	private int startAmount;
	private int amount;

	private Action collisionHandler;
	private Platform platform;


	public DestroyingPlatformComponent(Platform platform, DestroyOptions destroyOption,
		int amount,
		GameObject player)
	{
		this.platform = platform;
		this.player = player;

		collisionHandler = destroyOption switch
		{
			DestroyOptions.AfterNJumps => DestroyAfterNJumps,
			DestroyOptions.AfterNSeconds => DestroyAfterNSeconds,
			_ => throw new ArgumentException("Unexpected argument"),
		};

		startAmount = amount;
		this.amount = amount;

		Player.Respawned += Restart;
	}

	public override void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == player)
		{
			collisionHandler();
		}
	}

	private void DestroyAfterNJumps()
	{
		Debug.Log(amount);
		amount -= 1;

		if (amount == 0)
		{
			platform.Invoke(nameof(platform.DestroyPlatform), delayForJumpDestroy);
		}
	}

	private void DestroyAfterNSeconds()
	{
		platform.Invoke(nameof(platform.DestroyPlatform), amount);
	}

	private void Restart(object sender, EventArgs args)
	{
		platform.SetVisible(true);
		amount = startAmount;
	}

	public override void Dispose()
	{
		Player.Respawned -= Restart;
	}
}
