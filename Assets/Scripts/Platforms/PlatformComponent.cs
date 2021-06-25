using UnityEngine;
using System;

public abstract class PlatformComponent : IDisposable
{
	public virtual void OnTriggerEnter(Collider collider) { }

	public virtual void OnCollisionEnter(Collision collision) { }
	public virtual void Update() { }
	public virtual void OnTriggerExit(Collider collider) { }

	public virtual void Dispose() { }
}
