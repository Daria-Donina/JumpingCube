using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Coin : MonoBehaviour
{
	public virtual int Value { get; protected set; }

	public static UnityEvent<Coin> HitCoin;
	private GameObject player;

	// Start is called before the first frame update
	void Start()
	{
		player = Player.GameObject;
	}

	void OnTriggerEnter(Collider collider)
	{
		HitCoin?.Invoke(this);
		Destroy(gameObject);
	}
}
