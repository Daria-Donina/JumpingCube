using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public static class Purse
{
	static Purse()
	{
		Coin.HitCoin.AddListener(coin => Add(coin));
	}

	private static int coinCount = 0;

	public static int CoinCount
	{
		get => coinCount;
		private set
		{
			if (coinCount >= 0)
				coinCount = value;
		}
	}

	public static void Add(Coin coin)
	{
		CoinCount += coin.Value;
	}
}
