using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	private PlayerState state;

	private PlayerConfiguration configuration;
	public PlayerConfiguration Configuration
	{
		get => configuration;
		set
		{
			configuration = value;

			AutoJumpEnabled = configuration.AutoJumpEnabled;
			Speed = configuration.Speed;
			JumpHeight = configuration.JumpHeigth;
			JumpDelay = configuration.JumpDelay;
			JumpSpeed = configuration.JumpSpeed;
		}
	}

	public void SetState(PlayerState value)
	{
		state = value;
		state.UpdateState();
	}

	public void SetConfiguration(PlayerConfiguration configuration)
	{
		Configuration = configuration;
	}

	void Start()
	{
		state = PlayerState.GetCurrentState(gameObject);
		state.InitializeStates(gameObject);
		Configuration = state.GetConfiguration();

		SpawnPosition = gameObject.transform.position;
	}

	public static Vector3 SpawnPosition { get; private set; }
	public bool AutoJumpEnabled { get; private set; }
	public float Speed { get; private set; }
	public float JumpHeight { get; private set; }
	public float JumpDelay { get; private set; }
	public float JumpSpeed { get; private set; }
}