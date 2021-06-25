using UnityEngine;

class MovingPlatformComponent : PlatformComponent
{
	private float time;

	protected Transform Transform { get; private set; }
	private float movingSpeed;
	private Vector3 endPoint;

	private Vector3 startPoint;

	private const int movingAlign = 5;

	public MovingPlatformComponent(Transform transform, float movingSpeed, Vector3 endPoint)
	{
		Transform = transform;
		this.endPoint = endPoint;

		startPoint = transform.position;

		var distance = (startPoint - endPoint).magnitude;
		this.movingSpeed = movingSpeed * movingAlign / distance;
	}

	public override void Update()
	{
		time += movingSpeed * Time.deltaTime;
		var position = Mathf.PingPong(time, 1f);

		Transform.position = Vector3.Lerp(startPoint, endPoint, position);
	}
}
