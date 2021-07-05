using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CoinUI : UI
{
	protected override void Start()
	{
		base.Start();
		Coin.HitCoin.AddListener(coin => this.Display(Purse.CoinCount.ToString()));
	}
}
