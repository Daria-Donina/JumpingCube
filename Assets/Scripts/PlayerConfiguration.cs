using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Custom/Player")]
public class PlayerConfiguration : ScriptableObject
{
	[SerializeField] private bool autoJumpEnabled;

	[SerializeField] private float speed;

	[SerializeField] private float jumpHeigth;

	[SerializeField] private float jumpDelay;

	[SerializeField] private float jumpSpeed;

	public bool AutoJumpEnabledo => autoJumpEnabled;
	public float Speed => speed;
	public float JumpHeigth => jumpHeigth;
	public float JumpDelay => jumpDelay;
	public float JumpSpeed => jumpSpeed;
}
