using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
	[SerializeField]
	private PlayerConfiguration configuration;
	private static GameObject player;

	private static GameObject skin;

	#region public states
	public static CrateState Crate { get; protected set; }
	public static CrateItemState CrateItem { get; protected set; }
	public static CrateItemStrongState CrateItemStrong { get; protected set; }
	public static CrateStrongState CrateStrong { get; protected set; }
	#endregion

	public void InitializeStates(GameObject player)
	{
		PlayerState.player = player;

		Crate = player.GetComponentInChildren<CrateState>(true);
		CrateItem = player.GetComponentInChildren<CrateItemState>(true);
		CrateItemStrong = player.GetComponentInChildren<CrateItemStrongState>(true);
		CrateStrong = player.GetComponentInChildren<CrateStrongState>(true);
	}

	public static PlayerState GetCurrentState(GameObject player)
	{
		var i = -1;
		Transform child;

		do
		{
			child = player.transform.GetChild(++i);
		} while (!child);

		return child.GetComponent<PlayerState>();
	}

	public virtual PlayerConfiguration GetConfiguration() => configuration;

	public virtual void UpdateState() 
	{
		Skin = gameObject;
		player.GetComponent<Player>().SetConfiguration(configuration);
	}

	protected static GameObject Skin 
	{ 
		get => skin; 
		set
		{
			if (skin)
			{
				skin.SetActive(false);
			}
			else
			{
				skin = GetCurrentState(player).gameObject;
			}

			skin = value;
			skin.SetActive(true);
		}
	}
}
