using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PlayerState
{
	private GameObject skin;

	public static CrateState Crate { get; protected set; }
	public static CrateItemState CrateItem { get; protected set; }
	public static CrateItemStrongState CrateItemStrong { get; protected set; }
	public static CrateStrongState CrateStrong { get; protected set; }

	public virtual void UpdateState(GameObject player) { }

	protected GameObject Skin 
	{ 
		get => skin; 
		set
		{
			skin.SetActive(false);
			skin = value;
			skin.SetActive(true);
		}
	}
}
