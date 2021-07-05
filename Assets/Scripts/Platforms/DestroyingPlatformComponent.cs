using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class DestroyingPlatformComponent : PlatformComponent
{
	private const float delayForJumpDestroy = 0.3f;
	private const int waitTime = 1;

	private GameObject player;

	private int startAmount;
	private int amount;

	private Action CollisionHandler;
	private Platform platform;

	private IEnumerator destroyingSecondsCoroutine;

	public DestroyingPlatformComponent(Platform platform, DestroyOptions destroyOption,
		int amount,
		GameObject player)
	{
		this.platform = platform;
		this.player = player;

		CollisionHandler = destroyOption switch
		{
			DestroyOptions.AfterNJumps => DestroyAfterNJumps,
			DestroyOptions.AfterNSeconds => DestroyAfterNSeconds,
			_ => throw new ArgumentException("Unexpected argument"),
		};

		startAmount = amount;
		this.amount = amount;

		destroyingSecondsCoroutine = DestroyingSecondsCoroutine();

		Player.Respawned += Restart;
	}

	public override void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == player)
		{
			CollisionHandler();
		}
	}

	private void DestroyAfterNJumps()
	{
		amount -= 1;

		if (amount == 0)
		{
			platform.Invoke(nameof(platform.DestroyPlatform), delayForJumpDestroy);
		}
	}

	private void DestroyAfterNSeconds()
	{
		if (amount == startAmount)
		{
			platform.StartCoroutine(destroyingSecondsCoroutine);
		}
	}

	private IEnumerator DestroyingSecondsCoroutine()
	{
		Debug.Log("Destroy after " + amount);
		Debug.Log("started coroutine " + Time.time);

		yield return new WaitForSeconds(amount);

		amount = 0;

		platform.DestroyPlatform();

		Debug.Log("finished coroutine " + Time.time);
	}

	private void Restart(object sender, EventArgs args)
	{
		platform.SetVisible(true);
		amount = startAmount;
		platform.StopCoroutine(destroyingSecondsCoroutine);
	}

	public override void Dispose()
	{
		Player.Respawned -= Restart;
	}
}
