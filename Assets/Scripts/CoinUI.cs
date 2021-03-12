using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
	private Text text;
    private void Start()
	{
		text = GetComponent<Text>();
		Coin.CoinHit += (sender, EventArgs) => text.text = GameManager.CoinCount.ToString();
	}
}
