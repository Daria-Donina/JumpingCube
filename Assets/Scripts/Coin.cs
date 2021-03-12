using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CoinType
{
    Regular
}

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinType coinType;

    public static event EventHandler<EventArgs> CoinHit;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerSet += (sender, EventArgs) => player = Player.GameObject;

        CoinHit += (sender, EventArgs) => Destroy((GameObject)sender);
        CoinHit += (sender, EventArgs) =>
        {
            if ((GameObject)sender == gameObject)
			{
                switch (coinType)
                {
                    case CoinType.Regular:
                        GameManager.CoinCount += 1;
                        break;
                    default:
                        break;
                }
            }
        };
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Here i hit coin");

        Debug.Log("С кем столкнулись:", collider.gameObject);
        Debug.Log("Player: ", player);
        if (collider.gameObject == player)
        {
            CoinHit?.Invoke(gameObject, EventArgs.Empty);
            Destroy((GameObject)sender);
        }
    }
}
