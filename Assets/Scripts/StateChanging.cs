using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanging : MonoBehaviour
{
    private Player _player;
	private int _cycleCount;
	private List<PlayerState> _states;

	private void Start()
	{
		_player = gameObject.GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
    {
		_states = new List<PlayerState>
		{
			PlayerState.Crate,
			PlayerState.CrateItem,
			PlayerState.CrateItemStrong,
			PlayerState.CrateStrong
		};

		if (Time.time > 2f * _cycleCount)
		{
			_player.SetState(_states[_cycleCount % _states.Count]);
			_cycleCount++;
		}
    }
}
