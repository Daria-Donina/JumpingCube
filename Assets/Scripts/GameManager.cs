using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameManager
{
	private static int coinCount;

	public static int CoinCount
	{
		get => coinCount;
		set
		{
			if (value >= 0)
				coinCount = value;
		}
	}


}
