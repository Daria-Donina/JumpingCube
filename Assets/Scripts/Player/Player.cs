using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	private PlayerState state;

	[SerializeField]
	private PlayerConfiguration configuration;

	public void SetState(PlayerState value)
	{
		state = value;
		state.UpdateState(gameObject);
	}

	void Start()
	{
		SpawnPosition = gameObject.transform.position;
		AutoJumpEnabled = configuration.AutoJumpEnabled;
		Speed = configuration.Speed;
		jumpHeigthLocal = configuration.JumpHeigth;
		JumpDelay = configuration.JumpDelay;
		JumpSpeed = configuration.JumpSpeed;

		JumpTime = CalculateJumpTime();
	}

	public static Vector3 SpawnPosition { get; private set; }

	[SerializeField]
	private bool autoJumpEnabled;
	public static bool AutoJumpEnabled { get; private set; }

	[SerializeField]
	private float speed;
	public static float Speed { get; private set; }

	public static float JumpTime { get; private set; }

	[SerializeField]
	private float jumpHeigth;

	private static float jumpHeigthLocal;
	public static float JumpHeight
	{
		get => jumpHeigthLocal;
		private set
		{
			jumpHeigthLocal = value;
			JumpTime = CalculateJumpTime();
		}
	}

	[SerializeField]
	private float jumpDelay;
	public static float JumpDelay { get; private set; }

	[SerializeField]
	private float jumpSpeed;

	public static float JumpSpeed { get; private set; }

	//Не точно работает, реальное время полета больше.
	private static float CalculateJumpTime() =>
		(float)Math.Sqrt(4 * jumpHeigthLocal / -Physics.gravity.y);

	public GameObject GetPlayer() => gameObject;

}