using UnityEngine;
using System.Collections;
public class MovingComponent : MonoBehaviour
{
    public const float speedCollisionDown = 1.02f;
    private Joystick joystick;
    private Rigidbody rb;
    private Player player;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (player.AutoJumpEnabled)
        {
           // JumpSpeedControl();
        }
    }

    void OnCollisionStay(Collision collision)
	{
        if (player.AutoJumpEnabled && Time.time > timer + player.JumpDelay)
        {
            timer = Time.time;
            Jump();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * speedCollisionDown, rb.velocity.z);
        }
    }

	private void Jump() => 
        rb.AddForce(Vector3.up * player.JumpHeight, ForceMode.VelocityChange);

	private void JumpSpeedControl()
	{
        var vel = rb.velocity;
        vel.y -= player.JumpSpeed * Time.deltaTime;
        rb.velocity = vel;
    }

    private void Move()
	{
        var direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        transform.Translate(direction * player.Speed);
    }
}
