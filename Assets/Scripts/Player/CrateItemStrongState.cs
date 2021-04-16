﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class CrateItemStrongState : PlayerState
	{
		public override void UpdateState(GameObject player)
		{
			Skin = player.transform.Find("crateItemStrong").gameObject;
		}
	}
}
