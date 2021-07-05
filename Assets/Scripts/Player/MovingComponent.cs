using UnityEngine;
using DG.Tweening;

public class MovingComponent : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private float jumpDuration = 1f;
    [SerializeField]
    private int jumpNumber = 1;
    [SerializeField]
    private float moveDuration = 0f;

    private Joystick joystick;

	private void Awake()
	{
        joystick = FindObjectOfType<Joystick>();
	}

	private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
	{
        Jump();
    }

    private void Jump()
    {
        transform.DOJump(Vector3.up + transform.position, player.JumpHeight, jumpNumber, jumpDuration);
    }

    private void Move()
	{
        transform.DOMoveX(transform.position.x + joystick.Horizontal, moveDuration);
        transform.DOMoveZ(transform.position.z + joystick.Vertical, moveDuration);
    }
}
