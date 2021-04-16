using UnityEngine;
using System.Collections;
public class PlayerContoller : MonoBehaviour
{
    public float speedCollisionDown = 1.02f;
    private Joystick joystick;
    private Rigidbody rb;
    private float canJumpTime;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();

        if (Player.AutoJumpEnabled)
        {
            JumpSpeedControl();
        }
    }

    void OnCollisionStay(Collision collision)
	{
        if (Player.AutoJumpEnabled && Time.time > timer + Player.JumpDelay)
        {
            timer = Time.time;
            Jump();
            canJumpTime = Time.time + Player.JumpTime + Player.JumpDelay;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * speedCollisionDown, rb.velocity.z);
        }
    }

	private void Jump() => 
        rb.AddForce(Vector3.up * Player.JumpHeight, ForceMode.VelocityChange);

	private void JumpSpeedControl()
	{
        var vel = rb.velocity;
        vel.y -= Player.JumpSpeed * Time.deltaTime;
        rb.velocity = vel;
    }

    private void Moving()
	{
        var direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        transform.Translate(direction * Player.Speed);
    }
}
