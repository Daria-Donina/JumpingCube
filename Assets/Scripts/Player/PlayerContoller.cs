using UnityEngine;
using System.Collections;
public class PlayerContoller : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rb;

    private float canJumpTime;

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

    private float timer = 0f;
    void OnCollisionStay(Collision collision)
	{
        if (Player.AutoJumpEnabled && Time.time > timer + Player.JumpDelay)
        {
            timer = Time.time;
            Jump();
            canJumpTime = Time.time + Player.JumpTime + Player.JumpDelay;
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
